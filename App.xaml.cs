using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SimolatorDesktopApp_1
{
    using SimolatorDesktopApp_1.Model;
    using System;
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public SimulatorConnectorModel _simultorConnectorModel { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _simultorConnectorModel = new SimulatorConnectorModel();

            // Create main application window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
