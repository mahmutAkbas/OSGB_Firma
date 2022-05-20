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
    public partial class RandevuView : UserControl,IPageHelper
    {
        private DataFaktory _faktory;
        private Randevu _randevu;
        public RandevuView(DataFaktory dataFactory,int userId)
        {
            _faktory = dataFactory;
            InitializeComponent();
            
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            EditRandevu.SelectAll();    
            var text = EditRandevu.Selection.Text;
            _randevu.RandevuTarihi =(DateTime) DpRandevuTarihi.SelectedDate;
            _randevu.Aciklama = text;
            _randevu.YurutucuFirmaId = 1;
            var result = _faktory.RandevuFirmas.Add(_randevu);
        }

        private void BtnGuncelle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DpRandevuTarihi_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnRandevuDetay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRandevuSil_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Temizle()
        {
            DpRandevuTarihi.Text = "";
            EditRandevu.Selection.Text = "";


        }

        public void Listele()
        {
            throw new System.NotImplementedException();
        }
    }
}
