using Business;
using Entities.DTOs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WinUI.Views
{
    /// <summary>
    /// Interaction logic for EtkinlikZiyaretiView.xaml
    /// </summary>
    public partial class EtkinlikZiyaretiView : UserControl
    {
        private DataFaktory _dataFaktory;
        public EtkinlikZiyaretiView(DataFaktory dataFaktory)
        {
            _dataFaktory = dataFaktory; 
            InitializeComponent();
            Listele();
        }

        private void SbFirmaAdi_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SbFirmaAdi.Text.Length > 2)
            {
                var result = _dataFaktory.EtkinlikZiyarets.GetEtkinlikZiyaretByFirmaAdi(SbFirmaAdi.Text);
                DgRandevuList.ItemsSource = result.Success ? result.Data : null;
            }
            else
            {
                Listele();
            }
        }

        private void BtnGorevliEkle_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is EtkinlikZiyaretDto)
            {
                var ziyaret = (EtkinlikZiyaretDto)btn.DataContext;
                var form = new EtkinlikGorevliView(_dataFaktory, ziyaret.Id);
                form.ShowDialog();
            }
        }

        private void BtnGorevEkle_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is EtkinlikZiyaretDto)
            {
                var ziyaret = (EtkinlikZiyaretDto)btn.DataContext;
                var form = new EtkinlikGorevView(_dataFaktory, ziyaret.Id);
                form.ShowDialog();
            }

        }
      void  Listele()
        {
            var result = _dataFaktory.EtkinlikZiyarets.GetEtkinlikZiyaretDto();
            DgRandevuList.ItemsSource = result.Success ? result.Data:null;
        }
    }
}
