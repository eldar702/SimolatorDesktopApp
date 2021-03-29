using SimolatorDesktopApp_1.Model;
using SimolatorDesktopApp_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimolatorDesktopApp_1.View.controls
{
    /// <summary>
    /// Interaction logic for ConnectControl.xaml
    /// </summary>
    public partial class ConnectControl : UserControl
    {
        private const string disconnected = "Simulator Disconnected";
        private const string connected = "Simulator Connected";
        VMConnectControl _vmConnectControl;
        public ConnectControl()
        {
            InitializeComponent();
            _vmConnectControl = new VMConnectControl(new SimulatorConnectorModel());
            DataContext = _vmConnectControl;
        }

        private void connectDisplayStatus(string statusText, bool isConnected)
        {
            this.StatusConnectTextBlock.Visibility = Visibility.Visible; // change blockText to visiible
            this.StatusConnectTextBlock.Text = "Status: " + statusText;
            if (isConnected)
            {
                this.StatusConnectTextBlock.Foreground = Brushes.LightGreen;
            }
            else
            {
                this.StatusConnectTextBlock.Foreground = Brushes.Red;
            }
        }

        /// <summary>
        /// Connect button press.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPressedConnect(object sender, RoutedEventArgs e)
        {
            try
            {
                _vmConnectControl.VMConnect(ipContextTextBox.Text, Int32.Parse(portContextTextBox.Text));
                this.connectDisplayStatus(connected, true); // connect succsess
            }
            catch(Exception _exception)
            {
                this.connectDisplayStatus(disconnected, false); // connect failed
            }
        }
    }
}
