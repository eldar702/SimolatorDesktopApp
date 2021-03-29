using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimolatorDesktopApp_1.Model
{
    class SimulatorConnectorModel : ISimulatorConnector
    {
        // private static readonly Mutex mut = new Mutex();
        // public int conectionAttempts;
        TcpClient aClient;
        public bool isConnected = false;

        public void Connect(string ip, int port)
        {
            aClient = new TcpClient(ip, port);
            isConnected = true;
            SimulatorModel simulatorModel = new SimulatorModel(this);
            simulatorModel.startSimulator();
        }

        public void Disconnect()
        {
            if (isConnected)
            {
                aClient.Close();
                isConnected = false;
            }
        }

        public string Read()
        {
            throw new NotImplementedException();
        }

        public void Write(string command)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(command + "\n");

            try
            {
                NetworkStream stream = this.aClient.GetStream();
                stream.Flush();
                stream.Write(buffer, 0, buffer.Length);
                // Console.WriteLine("enter write scope");
            }
            catch
            {

            }
        }

        public string WriteCommand(string command)
        {
            throw new NotImplementedException();
        }
    }
}
