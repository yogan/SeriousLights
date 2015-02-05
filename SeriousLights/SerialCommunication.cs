using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
            WriteBytesToPort(CreateColorCommand(color));
            
            WriteBytesToPort(CreateLedCommand(0));
            WriteBytesToPort(CreateLedCommand(2));
            WriteBytesToPort(CreateLedCommand(10));

            WriteBytesToPort(CreateApplyCommand());
        }

        private byte[] CreateApplyCommand()
        {
            return new[] { (byte)'a' };
        }

        private byte[] CreateColorCommand(Color color)
        {
            return new[] { (byte)'c', color.R, color.G, color.B };
        }

        private byte[] CreateLedCommand(int i)
        {
            return new[] { (byte)'l', (byte)i };
        }

        private void WriteBytesToPort(byte[] bytes)
        {
            mySerialPort.Write(bytes, 0, bytes.Length);
        }

        public void Close()
        {
            mySerialPort.Close();
        }
    }
}
