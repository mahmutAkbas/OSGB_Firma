using Business;
using Entities.Concrete.Data;
using System.Windows;
using System.Windows.Controls;
using WinUI.Helper;

namespace WinUI.Views
{
    /// <summary>
    /// Interaction logic for UnvanEkle.xaml
    /// </summary>
    public partial class UnvanView : UserControl, IPageHelper
    {
        private DataFaktory _faktory;
        private Unvan _unvan;
        public UnvanView(DataFaktory faktory, int userId)
        {
            InitializeComponent();
            _faktory = faktory;
            Listele();
        }
        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            var result = _faktory.Unvans.Add(new Entities.Concrete.Data.Unvan() { UnvanAdi = EditUnvanAdi.Text });
            HandyControl.Controls.MessageBox.Show(result.Message, "Unvan Ekle", MessageBoxButton.OK, MessageBoxImage.Information);
            if (result.Success)
            {
                Listele();
                Temizle();
            }

        }
        private void BtnUnvanSil_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is Unvan)
            {
                var unvan = (Unvan)btn.DataContext;
                MessageBoxResult result = HandyControl.Controls.MessageBox.Show($"{unvan.UnvanAdi}  Silmek istediğinizden emin misiniz?", "Unvan Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var resultDelete = _faktory.Unvans.Delete(unvan);
                    HandyControl.Controls.MessageBox.Show(resultDelete.Message, "Unvan Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (resultDelete.Success)
                        Listele();
                }
            }
        }
        private void BtnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = HandyControl.Controls.MessageBox.Show($"{_unvan.UnvanAdi}  Güncellemek istediğinizden emin misiniz?", "Unvan Update", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _unvan.UnvanAdi = EditUnvanAdi.Text;
                var resultUpdate = _faktory.Unvans.Update(_unvan);
                HandyControl.Controls.MessageBox.Show(resultUpdate.Message, "Unvan Update", MessageBoxButton.OK, MessageBoxImage.Information);
                if (resultUpdate.Success)
                {
                    Listele();
                    Temizle();
                }
            }
        }

        private void BtnUnvanDetay_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is Unvan)
            {
                _unvan = (Unvan)btn.DataContext;
                EditUnvanAdi.Text = _unvan.UnvanAdi;
                BtnEkle.IsEnabled = false;
                BtnGuncelle.IsEnabled = true;
            }

        }
        public void Listele()
        {
            var result = _faktory.Unvans.GetAll();
            DgUnvanList.ItemsSource = result.Success ? result.Data : null;
        }
        public void Temizle()
        {
            _unvan = null;
            BtnEkle.IsEnabled = true;
            BtnGuncelle.IsEnabled = false;
            EditUnvanAdi.Text = "";
        }
        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            Temizle();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Temizle();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SbUnvanAdi.Text.Length > 2)
            {
                var result = _faktory.Unvans.GetAllFilter(SbUnvanAdi.Text);
                DgUnvanList.ItemsSource = result.Data;
            }
            else
            {
                Listele();
            }


        }

    }
}
