using Business;
using Entities.Concrete.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WinUI.Views
{
    /// <summary>
    /// Interaction logic for EtkinlikGorevView.xaml
    /// </summary>
    public partial class EtkinlikGorevView : Window
    {
        private DataFaktory _dataFaktory;
        private int _ziyaretId;
        public EtkinlikGorevView(DataFaktory dataFactory,int ziyaretId)
        {
            _dataFaktory = dataFactory;
            _ziyaretId = ziyaretId;
            InitializeComponent();
            Listele("");
            var combo = _dataFaktory.Islemlers.GetAll();
            CbIslemler.ItemsSource = combo.Success ? combo.Data : null;
        }

        private void SbIslemAdi_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SbIslemAdi.Text.Length > 2)
            {
                Listele(SbIslemAdi.Text);
            }
            else
            {
                Listele("");
            }
        }

        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            CbIslemler.Text = "";
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            var result = _dataFaktory.EtkinlikGorevleri.Add(new Entities.Concrete.Data.EtkinlikGorevleri()
            {
                Aciklama=EditAciklama.Text,
                EtkinlikZiyaretId=_ziyaretId,
                IslemId=(int)CbIslemler.SelectedValue,
                Tarih=DateTime.Now
            });
            HandyControl.Controls.MessageBox.Show(result.Message, "Görev Ekle", MessageBoxButton.OK, MessageBoxImage.Information);
            if (result.Success)
            {
                Listele("");
            }
        }
        void Listele(string personelAdi)
        {
            var result = _dataFaktory.EtkinlikGorevleri.GetEtkinlikGorevDtos(personelAdi);
            DgIslemList.ItemsSource = result.Success ? result.Data : null;
        }
    }
}
