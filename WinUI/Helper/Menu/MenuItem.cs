using Business;
using FontAwesome.WPF;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using WinUI.Views;

namespace WinUI.Helper.Menu
{
    public class MenuItem
    {
        public string Title { get; set; }
        public FontAwesomeIcon Image { get; set; }
        public UserControl Path { get; set; }
    }
    public class TreeViewMenuManager
    {
        public static List<MenuItem> Menus = new List<MenuItem>();

        public TreeViewMenuManager()
        {
            Menus = new List<MenuItem>();
        }
        public static List<MenuItem> GetMenu(DataFaktory dataFaktory,int userId)
        {
            Menus.Add(new MenuItem() { Title = "Personel", Image = FontAwesome.WPF.FontAwesomeIcon.UserOutline, Path = new PersonelView(dataFaktory,userId) });
            Menus.Add(new MenuItem() { Title = "Ünvan", Image = FontAwesome.WPF.FontAwesomeIcon.StarHalfOutline, Path = new UnvanView(dataFaktory, userId) });
            Menus.Add(new MenuItem() { Title = "Firma", Image = FontAwesome.WPF.FontAwesomeIcon.Home, Path = new YurutucuFirmaView(dataFaktory, userId) });
            Menus.Add(new MenuItem() { Title = "Randevu", Image = FontAwesome.WPF.FontAwesomeIcon.CalendarPlusOutline, Path = new RandevuView(dataFaktory, userId) });
            Menus.Add(new MenuItem() { Title = "İşlemler", Image = FontAwesome.WPF.FontAwesomeIcon.Tasks, Path = new IslemlerView(dataFaktory, userId) });
            Menus.Add(new MenuItem() { Title = "Randevular", Image = FontAwesome.WPF.FontAwesomeIcon.Calendar, Path = new RandevuListesi(dataFaktory) });
            Menus.Add(new MenuItem() { Title = "Etkinlik Ziyareti", Image = FontAwesome.WPF.FontAwesomeIcon.AreaChart, Path = new EtkinlikZiyaretiView(dataFaktory) });

            return Menus;
        }

    }
}
