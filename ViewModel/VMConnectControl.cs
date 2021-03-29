using SimolatorDesktopApp_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimolatorDesktopApp_1.ViewModel
{
    class VMConnectControl
    {
        SimulatorConnectorModel _simulatorConnectorModel;


        public VMConnectControl(SimulatorConnectorModel simulatorConnectorModel)
        {
            _simulatorConnectorModel = simulatorConnectorModel;
        }

        public void VMConnect(string ip, int port)
        {
            _simulatorConnectorModel.Connect(ip, port);
        }
    }
}
