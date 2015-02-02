using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace SeriousLights
{
    class SerialCommunication
    {
        private SerialPort mySerialPort;

        public SerialCommunication()
        {
            mySerialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One); // "8N1"
            mySerialPort.Open();
        }

        public void Write(Color color)
        {
            byte[] colorBytes = new[] { color.R, color.G, color.B };
            mySerialPort.Write(colorBytes, 0, 3);
        }

        public void Close()
        {
            mySerialPort.Close();
        }
    }
}
