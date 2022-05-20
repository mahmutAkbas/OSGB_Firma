using Business;
using Entities.Concrete.Data;
using System.Windows;
using System.Windows.Controls;
using WinUI.Helper;

namespace WinUI.Views
{
    /// <summary>
    /// Interaction logic for YurutucuFirmaView.xaml
    /// </summary>
    public partial class YurutucuFirmaView : UserControl, IPageHelper
    {
        private DataFaktory _faktory;
        private YurutucuFirma _yurutucuFirma;
        public YurutucuFirmaView(DataFaktory dataFaktory, int userId)
        {
            _faktory = dataFaktory;
            InitializeComponent();
            Listele();
        }


        private void SbFirmaAdi_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(SbFirmaAdi.Text.Length > 2)
            {
                DgFirmaList.ItemsSource = _faktory.YurutucuFirmas.GetAllFilter(SbFirmaAdi.Text).Data;
            }
            else
            {
                Listele();
            }
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            _yurutucuFirma = new YurutucuFirma()
            {
                Adi = EditFirmaAdi.Text
            };
            var result = _faktory.YurutucuFirmas.Add(_yurutucuFirma);
            System.Windows.Forms.MessageBox.Show(result.Message, "Firma Ekle", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            if (result.Success)
                Listele();

        }

        private void BtnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = HandyControl.Controls.MessageBox.Show($"{_yurutucuFirma.Adi}  Güncellemek istediğinizden emin misiniz?", "Firma Update", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _yurutucuFirma.Adi = EditFirmaAdi.Text;
                var resultUpdate = _faktory.YurutucuFirmas.Update(_yurutucuFirma);
                HandyControl.Controls.MessageBox.Show(resultUpdate.Message, "Firma Update", MessageBoxButton.OK, MessageBoxImage.Information);
                if (resultUpdate.Success)
                {
                    Listele();
                    Temizle();
                }
            }
        }

        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            Temizle();
        }

        private void BtnFirmaDetay_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is YurutucuFirma)
            {
                _yurutucuFirma = (YurutucuFirma)btn.DataContext;
                EditFirmaAdi.Text = _yurutucuFirma.Adi;
                BtnEkle.IsEnabled = false;
                BtnGuncelle.IsEnabled = true;
            }
        }

        private void BtnFirmaSil_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is YurutucuFirma)
            {
                var firma = (YurutucuFirma)btn.DataContext;
                MessageBoxResult result = HandyControl.Controls.MessageBox.Show($"{firma.Adi}  Silmek istediğinizden emin misiniz?", "Firma Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var resultDelete = _faktory.YurutucuFirmas.Delete(firma);
                    HandyControl.Controls.MessageBox.Show(resultDelete.Message, "Firma Delete", MessageBoxButton.OK, MessageBoxImage.Information);
                    Listele();
                }
            }
        }
        public void Temizle()
        {
            _yurutucuFirma = null;
            BtnEkle.IsEnabled = true;
            BtnGuncelle.IsEnabled = false;
            EditFirmaAdi.Text = "";
        }
        public void Listele()
        {
            var result = _faktory.YurutucuFirmas.GetAll();
            DgFirmaList.ItemsSource = result.Success ? result.Data : null;
        }
    }
}
