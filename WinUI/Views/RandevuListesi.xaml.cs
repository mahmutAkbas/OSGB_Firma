using Business;
using Entities.DTOs;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WinUI.Views
{
    /// <summary>
    /// Interaction logic for RandevuListesi.xaml
    /// </summary>
    public partial class RandevuListesi : UserControl
    {
        private DataFaktory _dataFaktory;
        public RandevuListesi(DataFaktory faktory)
        {
            _dataFaktory = faktory;
            InitializeComponent();
            Listele();
        }

        private void SbFirmaAdi_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (SbRandevuTarihi.SelectedDate != null && SbFirmaAdi.Text.Length > 2)
            {
                var result = _dataFaktory.RandevuFirmas.GetRandevuDtoAllFilter(((DateTime)SbRandevuTarihi.SelectedDate), SbFirmaAdi.Text, (bool)TgOnayDurumu.IsChecked);
                DgRandevuList.ItemsSource = result.Success ? result.Data : null;
            }
            if (SbRandevuTarihi.SelectedDate != null)
            {
                var result = _dataFaktory.RandevuFirmas.GetRandevuDtoAllFilter(((DateTime)SbRandevuTarihi.SelectedDate), "", (bool)TgOnayDurumu.IsChecked);
                DgRandevuList.ItemsSource = result.Success ? result.Data : null;
            }
            if (SbFirmaAdi.Text.Length > 2)
            {
                var result = _dataFaktory.RandevuFirmas.GetRandevuDtoAllFilter(DateTime.MinValue, SbFirmaAdi.Text, (bool)TgOnayDurumu.IsChecked);
                DgRandevuList.ItemsSource = result.Success ? result.Data : null;
            }

        }

        private void TgOnayDurumu_Click(object sender, RoutedEventArgs e)
        {
            Listele();
        }

        private void BtnRandevuOnay_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.DataContext is RandevuDto)
            {
                var result = btn.DataContext as RandevuDto;
                if (result.Onay != true)
                {
                    var form = new EtkinlikZiyareti(_dataFaktory, this, result);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Oluşturulan etkinliği tekrar ekleyemezsiniz");
                }
              
            }
        }

        private void SbRandevuTarihi_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            if (SbRandevuTarihi.SelectedDate != null && SbFirmaAdi.Text.Length > 2)
            {
                var result = _dataFaktory.RandevuFirmas.GetRandevuDtoAllFilter(((DateTime)SbRandevuTarihi.SelectedDate), SbFirmaAdi.Text, (bool)TgOnayDurumu.IsChecked);
                DgRandevuList.ItemsSource = result.Success ? result.Data : null;
            }
            if (SbRandevuTarihi.SelectedDate != null)
            {
                var result = _dataFaktory.RandevuFirmas.GetRandevuDtoAllFilter(((DateTime)SbRandevuTarihi.SelectedDate), "   ", (bool)TgOnayDurumu.IsChecked);
                DgRandevuList.ItemsSource = result.Success ? result.Data : null;
            }
            if (SbFirmaAdi.Text.Length > 2)
            {
                var result = _dataFaktory.RandevuFirmas.GetRandevuDtoAllFilter(DateTime.MinValue, SbFirmaAdi.Text, (bool)TgOnayDurumu.IsChecked);
                DgRandevuList.ItemsSource = result.Success ? result.Data : null;
            }

        }
        public void Listele()
        {
            var result = _dataFaktory.RandevuFirmas.GetRandevuDtoAllByOnay((bool)TgOnayDurumu.IsChecked);
            DgRandevuList.ItemsSource = result.Success ? result.Data : null;
        }
    }
}
