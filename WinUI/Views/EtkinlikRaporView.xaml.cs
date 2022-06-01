using Business;
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
    /// Interaction logic for EtkinlikRaporView.xaml
    /// </summary>
    public partial class EtkinlikRaporView : Window
    {
        public EtkinlikRaporView(DataFaktory _dataFaktory,int _ziyaretId)
        {
            InitializeComponent();
            var resultGorevli = _dataFaktory.EtkinlikGorevlileri.GetDtos("",_ziyaretId);
            DgGorevliList.ItemsSource = resultGorevli.Success ? resultGorevli.Data : null;
            var resultIslem = _dataFaktory.EtkinlikGorevleri.GetEtkinlikGorevDtos("",_ziyaretId);
            DgIslemList.ItemsSource = resultIslem.Success ? resultIslem.Data : null;
        }
    }
}
