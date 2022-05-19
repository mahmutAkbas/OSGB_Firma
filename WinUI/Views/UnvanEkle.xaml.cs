using Business;
using Entities.Concrete.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WinUI.Views
{
    /// <summary>
    /// Interaction logic for UnvanEkle.xaml
    /// </summary>
    public partial class UnvanEkle : UserControl
    {
        private DataFaktory _faktory;
        private Unvan _unvan;
        public UnvanEkle(DataFaktory faktory)
        {
            InitializeComponent();
            _faktory = faktory;
            UnvanListele();
            BtnEkle.IsEnabled = true;
            BtnGuncelle.IsEnabled = false;
        }

        private async void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            var result = await _faktory.Unvans.Add(new Entities.Concrete.Data.Unvan() { UnvanAdi = EditUnvanAdi.Text });
            System.Windows.Forms.MessageBox.Show(result.Message, "Unvan Ekle", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            UnvanListele();
        }
        private async void BtnUnvanSil_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is Unvan)
            {
                var unvan = (Unvan)btn.DataContext;
                MessageBoxResult result = MessageBox.Show($"{unvan.UnvanAdi}  Silmek istediğinizden emin misiniz?", "Unvan Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var resultDelete = await _faktory.Unvans.Delete(unvan);
                    MessageBox.Show(resultDelete.Message, "Unvan Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                    UnvanListele();
                }
            }
        }

        private async void BtnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show($"{_unvan.UnvanAdi}  Güncellemek istediğinizden emin misiniz?", "Unvan Update", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _unvan.UnvanAdi = EditUnvanAdi.Text;
                var resultDelete = await _faktory.Unvans.Update(_unvan);
                MessageBox.Show(resultDelete.Message, "Unvan Update", MessageBoxButton.OK, MessageBoxImage.Information);
                UnvanListele();
                BtnEkle.IsEnabled = true;
                BtnGuncelle.IsEnabled = false;
                EditUnvanAdi.Text = "";
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
        public async void UnvanListele()
        {
            var result = await _faktory.Unvans.GetAll();
            DgUnvanList.ItemsSource = result.Success ? result.Data : null;
        }

        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            _unvan = null;
            BtnEkle.IsEnabled = true;
            BtnGuncelle.IsEnabled = false;
            EditUnvanAdi.Text = "";
        }
    }
}
