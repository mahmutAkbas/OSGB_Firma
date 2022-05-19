using Business;
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
        public UnvanEkle(DataFaktory faktory)
        {
            InitializeComponent();
            _faktory = faktory;
            UnvanListele();
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            var result = _faktory.Unvans.Add(new Entities.Concrete.Data.Unvan() { UnvanAdi = EditUnvanAdi.Text });
            System.Windows.Forms.MessageBox.Show(result.Message, "Unvan Ekle", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            UnvanListele();
        }
        private void BtnUnvanSil_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnGuncelle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUnvanDetay_Click(object sender, RoutedEventArgs e)
        {

        }
        public void UnvanListele()
        {
            DgUnvanList.ItemsSource = _faktory.Unvans.GetAll().Success ? _faktory.Unvans.GetAll().Data : null;
        }
    }
}
