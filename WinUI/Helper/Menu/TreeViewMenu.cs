using FontAwesome.WPF;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace WinUI.Helper.Menu
{
    public class TreeViewMenu
    {
        public TreeViewMenu()
        {
            this.Children = new ObservableCollection<TreeViewMenuChlid>();
        }
        public ObservableCollection<TreeViewMenuChlid> Children { get; set; }
        public string Title { get; set; }
        public FontAwesomeIcon Image { get; set; }
    }
    public class TreeViewMenuChlid
    {
        public string Title { get; set; }
        public FontAwesomeIcon Image { get; set; }
        public UserControl Path { get; set; }
    }
}
