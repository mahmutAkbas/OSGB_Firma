using Business;
using Entities.Concrete.Data;
using System.Windows;
using System.Windows.Controls;
using WinUI.Helper;

namespace WinUI.Views
{
    /// <summary>
    /// Interaction logic for IslemlerView.xaml
    /// </summary>
    public partial class IslemlerView : IPageHelper
    {
        private DataFaktory _faktory;
        private int _userId;
        private Islemler _islemler;
        public IslemlerView(DataFaktory dataFaktory, int userId)
        {
            _faktory = dataFaktory;
            _userId = userId;
            InitializeComponent();
            Listele();
            Temizle();
        }

        private void BtnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = HandyControl.Controls.MessageBox.Show($"{_islemler.Adi} güncellemek istediğinizden emin misiniz?", "İşlem Update", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {

                _islemler.Adi = EditIslemAdi.Text;
                _islemler.Tip = CbIslemTip.SelectedIndex;
                var resultUpdate = _faktory.Islemlers.Update(_islemler);
                HandyControl.Controls.MessageBox.Show(resultUpdate.Message, "İşlem Update", MessageBoxButton.OK, MessageBoxImage.Information);
                if (resultUpdate.Success)
                {
                    Listele();
                    Temizle();
                }
            }
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            var result = _faktory.Islemlers.Add(new Islemler()
            {
                Adi = EditIslemAdi.Text,
                Tip = CbIslemTip.SelectedIndex
            });
            HandyControl.Controls.MessageBox.Show(result.Message, "Unvan Ekle", MessageBoxButton.OK, MessageBoxImage.Information);
            if (result.Success)
            {
                Listele();
                Temizle();
            }
        }

        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            Temizle();
        }



        private void BtnIslemSil_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is Islemler)
            {
                var islem = (Islemler)btn.DataContext;
                MessageBoxResult result = HandyControl.Controls.MessageBox.Show($"{islem.Adi}  silmek istediğinizden emin misiniz?", "İşlem Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var resultDelete = _faktory.Islemlers.Delete(islem);
                    HandyControl.Controls.MessageBox.Show(resultDelete.Message, "İşlem Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (resultDelete.Success)
                        Listele();
                }
            }
        }

        private void BtnIslemDetay_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is Islemler)
            {
                _islemler = (Islemler)btn.DataContext;
                EditIslemAdi.Text = _islemler.Adi;
                CbIslemTip.SelectedIndex = _islemler.Tip;
                BtnEkle.IsEnabled = false;
                BtnGuncelle.IsEnabled = true;
            }
        }

        public void Temizle()
        {
            EditIslemAdi.Text = "";
            EditIslemAdi.Text = "";
            BtnEkle.IsEnabled = true;
            BtnGuncelle.IsEnabled = false;
        }
        public void Listele()
        {
            var result = _faktory.Islemlers.GetAll();
            DgIslemList.ItemsSource = result.Success ? result.Data : null;
        }

        private void SbIslemAdi_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SbIslemAdi.Text.Length > 2)
            {
                DgIslemList.ItemsSource = _faktory.Islemlers.GetAllFilter(SbIslemAdi.Text).Data;
            }
            else
            {
                Listele();
            }
        }
    }
}
