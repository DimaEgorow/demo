using System.Configuration;
using System.Data;
using System.Windows;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static WpfApp6.Models.DemoMaterial5Context DB = new Models.DemoMaterial5Context();
        public static int Mode { get; set; }
        public static Models.Partner currentPatner = null;
    }

}
