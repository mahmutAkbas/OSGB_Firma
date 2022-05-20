using Business;
using Entities.Concrete.Data;
using Entities.DTOs;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using WinUI.Helper;

namespace WinUI.Views
{
    /// <summary>
    /// Interaction logic for PersonelView.xaml
    /// </summary>
    public partial class PersonelView : UserControl,IPageHelper
    {
        private DataFaktory _dataFaktory;
        private Personel _personel;
        public PersonelView(DataFaktory dataFaktory,int userId)
        {
            _dataFaktory = dataFaktory;
            InitializeComponent();

        }
        private void PersonelPage_Loaded(object sender, RoutedEventArgs e)
        {
            var resultUnvan = _dataFaktory.Unvans.GetAll();
            ComUnvan.ItemsSource = resultUnvan.Success ? resultUnvan.Data : null;
            Listele();
            Temizle();
        }
        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            _personel = new Personel()
            {
                Adi = EditAdi.Text,
                Soyadi = EditSoyadi.Text,
                Telefon = EditTelefon.Text,
                UnvanId = Convert.ToInt16(ComUnvan.SelectedValue)
            };
            var result = _dataFaktory.Personels.Add(_personel);
            HandyControl.Controls.MessageBox.Show(result.Message, "Personel Ekleme İşlemi", MessageBoxButton.OK, MessageBoxImage.Information);

            if (result.Success)
            {
                _personel = null;
                Listele();
                Temizle();
            }
        }

        private void BtnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (_personel.SilinmeDurumu)
            {
                HandyControl.Controls.MessageBox.Show($"{_personel.Adi + " " + _personel.Soyadi}  personel silindiği için güncelleme yapazsınız", "Personel Güncelleme İşlemi", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBoxResult result = HandyControl.Controls.MessageBox.Show($"{_personel.Adi + " " + _personel.Soyadi}  Güncellemek istediğinizden emin misiniz?", "Personel Güncelleme İşlemi", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _personel.Adi = EditAdi.Text;
                    _personel.Soyadi = EditSoyadi.Text;
                    _personel.Telefon = EditTelefon.Text;
                    _personel.UnvanId = Convert.ToInt16(ComUnvan.SelectedValue);
                    _personel.SilinmeDurumu = _personel.SilinmeDurumu;
                    var resultUpdate = _dataFaktory.Personels.Update(_personel);
                    HandyControl.Controls.MessageBox.Show(resultUpdate.Message, "Personel Güncelleme İşlemi", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (resultUpdate.Success)
                    {
                        Listele();
                        Temizle();
                    }
                }

            }

        }

        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            Temizle();
        }


        private void BtnPersonelSil_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is PersonelDto)
            {
                PersonelDoldur((PersonelDto)btn.DataContext);
                if ((bool)TgSilinmeDurumu.IsChecked)
                {
                    _personel.SilinmeTarihi = DateTime.Now;
                    _personel.SilinmeDurumu = false;
                }
                else
                {
                    _personel.SilinmeTarihi = DateTime.MinValue;
                    _personel.SilinmeDurumu = true;
                }
                MessageBoxResult result = HandyControl.Controls.MessageBox.Show($"{_personel.Adi + " " + _personel.Soyadi}  Silmek istediğinizden emin misiniz?", "Personel Silme İşlemi", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var resultDelete = _dataFaktory.Personels.Update(_personel);
                    HandyControl.Controls.MessageBox.Show(resultDelete.Message, "Personel Silme İşlemi", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (resultDelete.Success)
                        Listele();
                }
            }
        }

        private void BtnPersonelDetay_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is PersonelDto)
            {
                PersonelDoldur((PersonelDto)btn.DataContext);
                EditAdi.Text = _personel.Adi;
                EditSoyadi.Text = _personel.Soyadi;
                EditTelefon.Text = _personel.Telefon;
                ComUnvan.SelectedValue = _personel.UnvanId;
                BtnEkle.IsEnabled = false;
                BtnGuncelle.IsEnabled = true;
            }
        }
       public void Listele()
        {
            var resultPersonel = _dataFaktory.Personels.GetAllPersonelDto((bool)TgSilinmeDurumu.IsChecked);
            DgPersonelList.ItemsSource = resultPersonel.Success ? resultPersonel.Data : null;

        }
        public void Temizle()
        {
            BtnEkle.IsEnabled = true;
            BtnGuncelle.IsEnabled = false;
            EditAdi.Text = "";
            EditSoyadi.Text = "";
            EditTelefon.Text = "";
            ComUnvan.Text = "";
        }
        void PersonelDoldur(PersonelDto personel)
        {
            _personel = new Personel()
            {
                Adi = personel.Adi,
                Id = personel.Id,
                KayitTarihi = personel.KayitTarihi,
                SilinmeTarihi = personel.SilinmeTarihi,
                Soyadi = personel.Soyadi,
                Telefon = personel.Telefon,
                UnvanId = personel.UnvanId,
                SilinmeDurumu = personel.SilinmeDurumu
            };

        }

        private void SbPersonel_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SbPersonel.Text.Length > 2)
            {
                var result = _dataFaktory.Personels.GetAllFilter(SbPersonel.Text, (bool)TgSilinmeDurumu.IsChecked);
                DgPersonelList.ItemsSource = result.Success ? result.Data : null;
            }
            else
            {
                Listele();
            }
        }



        private void TgSilinmeDurumu_Click(object sender, RoutedEventArgs e)
        {
            Listele();

        }

        private void EditTelefon_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
