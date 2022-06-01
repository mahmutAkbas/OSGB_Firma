using Business;
using Entities.DTOs;
using System;
using System.Windows;

namespace WinUI.Views
{
    /// <summary>
    /// Interaction logic for EtkinlikZiyareti.xaml
    /// </summary>
    public partial class EtkinlikZiyareti : Window
    {
        private RandevuListesi _randevuListesi;
        private DataFaktory _faktory;
        private RandevuDto _randevu;
        public EtkinlikZiyareti(DataFaktory factory, RandevuListesi randevuListesi, RandevuDto randevu)
        {
            _randevuListesi = randevuListesi;
            _faktory = factory;
            _randevu = randevu; 
            InitializeComponent();
            var comboHekim = _faktory.Personels.GetAllPersonelDto(false);
            CbIsgGorevli.ItemsSource = comboHekim.Data;
            CbHekimGorevli.ItemsSource=comboHekim.Data;
        }

        private void BtnEkle_Click(object sender, RoutedEventArgs e)
        {
            var msgResult = MessageBox.Show("Ziyaret oluşturmak istermisiniz", "Ziyaret", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (msgResult == MessageBoxResult.Yes)
            {
                if (((PersonelDto)CbHekimGorevli.SelectedValue).Id != ((PersonelDto)CbIsgGorevli.SelectedValue).Id) { 
                
              
                var resultZiyaret = _faktory.EtkinlikZiyarets.AddCustom(new Entities.Concrete.Data.EtkinlikZiyaret()
                {
                    RandevuId=_randevu.Id,
                    AylikUcret = Convert.ToDecimal(EditUcret.Text)
                });
                if (resultZiyaret.Success)
                {
                    var resultGorevli = _faktory.EtkinlikGorevlileri.Add(new Entities.Concrete.Data.EtkinlikGorevlileri()
                    {
                        EtkinlikZiyaretId = resultZiyaret.Data,
                        PersonelId = ((PersonelDto)CbHekimGorevli.SelectedValue).Id,
                        Yetki = "Hekim"
                    });
                    if (resultGorevli.Success)
                    {
                        resultGorevli = _faktory.EtkinlikGorevlileri.Add(new Entities.Concrete.Data.EtkinlikGorevlileri()
                        {
                            EtkinlikZiyaretId = resultZiyaret.Data,
                            PersonelId = ((PersonelDto)CbIsgGorevli.SelectedValue).Id,
                            Yetki = "İş Güvenlik Uzmanı"
                        });
                        if (resultGorevli.Success)
                        {
                                var resultRandevu = _faktory.RandevuFirmas.Update(new Entities.Concrete.Data.Randevu
                                {
                                    Id=_randevu.Id,
                                    Onay=   true,
                                    Aciklama=_randevu.Aciklama,
                                    RandevuTarihi= _randevu.RandevuTarihi,
                                    YurutucuFirmaId=_randevu.YurutucuFirmaId,
                                });
                                if (resultRandevu.Success) { 
                            MessageBox.Show(resultZiyaret.Message, "Ziyaret", MessageBoxButton.OK, MessageBoxImage.Information);
                                    _randevuListesi.Listele();
                                }
                            }
                    }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen farklı personel seçiniz.", "Personel Seçim Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void BtnTemizle_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var comboHekim = _faktory.Personels.GetAllPersonelDto(false);
            CbIsgGorevli.ItemsSource = comboHekim.Data;
            CbHekimGorevli.ItemsSource = comboHekim.Data;
        }
    }
}
