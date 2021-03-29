using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private bool isConnected = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsConnected
        {
            get { return isConnected; }
            set
            {
                isConnected = value;
                INotifyPropertyChanged("IsConnected");
            }
        }

        public void INotifyPropertyChanged(string propName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public void Connect(string ip, int port)
        {
            aClient = new TcpClient(ip, port);
            IsConnected = true; // set property connect
           // SimulatorModel simulatorModel = new SimulatorModel(this);
           // simulatorModel.startSimulator();
        }

        public void Disconnect()
        {
            if (IsConnected)
            {
                aClient.Close();
                IsConnected = false;
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
