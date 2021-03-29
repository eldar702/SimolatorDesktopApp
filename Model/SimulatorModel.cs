using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimolatorDesktopApp_1.Model
{
    class SimulatorModel
    {
        private SimulatorConnectorModel _simulatorConnector;
        private string path = "C:/Users/Asus/source/repos/SimolatorDesktopApp_1_Update_to26.3/SimolatorDesktopApp_1/reg_flight.csv";

        public SimulatorModel(SimulatorConnectorModel simulatorConnector)
        {
            _simulatorConnector = simulatorConnector;
        }

        public void startSimulator()
        {
            Thread t = new Thread(delegate()
            {
                IuploadFile iuploadFile = new IuploadFile();
                string[] lines = iuploadFile.ReadFile(path);
                int numLines = lines.Length;
                int i = 0;
                while (i < numLines && _simulatorConnector.isConnected)
                {
                    Console.WriteLine(lines[i]);
                    _simulatorConnector.Write(lines[i]);
                    Thread.Sleep(100);
                    i++;
                }
                _simulatorConnector.Disconnect();
            });
            t.Start();
        }
    }
}
