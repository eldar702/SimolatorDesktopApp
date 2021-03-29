﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimolatorDesktopApp_1.Model
{
    public interface ISimulatorConnector
    {
        void Connect(string ip, int port);
        void Write(string command);
        string Read();
        void Disconnect();
        string WriteCommand(string command);
    }
}
