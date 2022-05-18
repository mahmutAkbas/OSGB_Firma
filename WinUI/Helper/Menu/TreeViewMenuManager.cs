using System.Collections.Generic;
using WinUI.Views;

namespace WinUI.Helper.Menu
{
    public class TreeViewMenuManager
    {
        public static List<TreeViewMenu> Items = new List<TreeViewMenu>();

        public TreeViewMenuManager()
        {
            Items = new List<TreeViewMenu>();
        }
        public static List<TreeViewMenu> GetMenu()
        {
            TreeViewMenu menu = new TreeViewMenu() { Title = "Ünvan", Image = FontAwesome.WPF.FontAwesomeIcon.StarOutline};
            menu.Children.Add(new TreeViewMenuChlid() { Title = "Ünvan Ekle", Image = FontAwesome.WPF.FontAwesomeIcon.Plus, Path = new UnvanEkle() });
            Items.Add(menu);
            return Items;
        }

    }
}
