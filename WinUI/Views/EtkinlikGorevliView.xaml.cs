using Business;
using Entities.DTOs;
using System.Windows;
using System.Windows.Controls;

namespace WinUI.Views
{
    /// <summary>
    /// Interaction logic for EtkinlikGorevliView.xaml
    /// </summary>
    public partial class EtkinlikGorevliView : Window
    {
        private DataFaktory _dataFaktory;
        private int _ziyaretId;
        public EtkinlikGorevliView(DataFaktory dataFaktory,int ziyaretId)
        {
            _dataFaktory = dataFaktory;
            _ziyaretId = ziyaretId;
            InitializeComponent();
            Listele("");
            var combo = _dataFaktory.Personels.GetAllPersonelDto(false);
            CbIsgGorevli.ItemsSource = combo.Success ? combo.Data : null;
        }

        private void SbGorevliAdi_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SbGorevliAdi.Text.Length > 2)
            {
                Listele(SbGorevliAdi.Text);
            }
            else
            {
                Listele("");
            }
        }


        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            CbIsgGorevli.Text = "";
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            var result = _dataFaktory.EtkinlikGorevlileri.Add(new Entities.Concrete.Data.EtkinlikGorevlileri(){
                EtkinlikZiyaretId = _ziyaretId,
                PersonelId = ((PersonelDto)CbIsgGorevli.SelectedValue).Id,
                Yetki="Yardımcı"
            });
            HandyControl.Controls.MessageBox.Show(result.Message, "Görevli Ekle", MessageBoxButton.OK, MessageBoxImage.Information);
            if (result.Success)
            {
                Listele("");
            }
        }
        void Listele(string personelAdi)
        {
            var result = _dataFaktory.EtkinlikGorevlileri.GetDtos(personelAdi);
            DgGorevliList.ItemsSource = result.Success ? result.Data : null;
        }
    }
}
