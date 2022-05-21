using Business;
using Entities.Concrete.Data;
using System;
using System.Windows;
using System.Windows.Controls;
using WinUI.Helper;

namespace WinUI.Views
{
    /// <summary>
    /// Interaction logic for RandevuView.xaml
    /// </summary>
    public partial class RandevuView : UserControl, IPageHelper
    {
        private DataFaktory _faktory;
        private Randevu _randevu;
        private int _userId;
        public RandevuView(DataFaktory dataFactory, int userId)
        {
            _faktory = dataFactory;
            _userId = userId;
            InitializeComponent();
            Listele();
            Temizle();
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            _randevu=new Randevu();
            _randevu.RandevuTarihi = (DateTime)DppRandevuTarihi.SelectedDate;
            _randevu.Aciklama = EditAciklama.Text;
            _randevu.YurutucuFirmaId = _userId;
            _randevu.Onay = false;
            var result = _faktory.RandevuFirmas.Add(_randevu);
            HandyControl.Controls.MessageBox.Show(result.Message, "Unvan Ekle", MessageBoxButton.OK, MessageBoxImage.Information);
            if (result.Success)
            {
                Listele();
                Temizle();
            }
        }

        private void BtnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (!_randevu.Onay) { 
            MessageBoxResult result = HandyControl.Controls.MessageBox.Show($"{_randevu.RandevuTarihi} Kaydı güncellemek istediğinizden emin misiniz?", "Randevu Update", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
     
                _randevu.Aciklama = EditAciklama.Text;
                _randevu.RandevuTarihi = (DateTime)DppRandevuTarihi.SelectedDate;
                var resultUpdate = _faktory.RandevuFirmas.Update(_randevu);
                HandyControl.Controls.MessageBox.Show(resultUpdate.Message, "Randevu Update", MessageBoxButton.OK, MessageBoxImage.Information);
                if (resultUpdate.Success)
                {
                    Listele();
                    Temizle();
                }
            }
            }
            else
            {
                BtnEkle.IsEnabled = false;
                BtnEkle.IsEnabled = false;
            }
        }

        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            Temizle();
        }

        private void DpRandevuTarihi_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DpRandevuTarihi.SelectedDate != null)
            {
                DgFirmaList.ItemsSource = _faktory.RandevuFirmas.GetAllByDate((DateTime)DpRandevuTarihi.SelectedDate, _userId).Data;
            }
            else
            {
                Listele();
            }
           

        }

        private void BtnRandevuDetay_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is Randevu)
            {
                _randevu = (Randevu)btn.DataContext;
                EditAciklama.Text = _randevu.Aciklama;
                DppRandevuTarihi.SelectedDate = _randevu.RandevuTarihi;
                BtnEkle.IsEnabled = false;
                BtnGuncelle.IsEnabled = true;
            }
        }

        private void BtnRandevuSil_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is Randevu)
            {
                var randevu = (Randevu)btn.DataContext;
                MessageBoxResult result = HandyControl.Controls.MessageBox.Show($"{randevu.RandevuTarihi} 'li kaydı   silmek istediğinizden emin misiniz?", "Randevu Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var resultDelete = _faktory.RandevuFirmas.Delete(randevu);
                    HandyControl.Controls.MessageBox.Show(resultDelete.Message, "Randevu Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (resultDelete.Success)
                        Listele();
                }
            }
        }

        public void Temizle()
        {
            DppRandevuTarihi.SelectedDate = null;
            EditAciklama.Text = "";
            BtnEkle.IsEnabled = true;
            BtnGuncelle.IsEnabled = false;
        }

        public void Listele()
        {
            var result= _faktory.RandevuFirmas.GetAllById(_userId);
            DgFirmaList.ItemsSource = result.Success?result.Data:null;
        }
    }
}
