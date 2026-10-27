using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfAppProject1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Console.WriteLine("App:OnStartup");
            base.OnStartup(e);
        }

        protected override void OnActivated(EventArgs e)
        {
            Console.WriteLine("App:OnActivated");
            base.OnActivated(e);
        }
        protected override void OnDeactivated(EventArgs e)
        {
            Console.WriteLine("App:OnDeactivated");
            base.OnDeactivated(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Console.WriteLine("App:OnExit");
            base.OnExit(e);
        }
    }

}
