using HandyControl.Tools;
using System.Windows;
using System.Windows.Navigation;

namespace WinUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ConfigHelper.Instance.SetLang("en");
            base.OnStartup(e);
        }
    }
}
