using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ParentClient
{
    internal class Client
    {
        private TcpClient _client;

        private StreamReader _sr;
        private StreamWriter _sw;

        private bool _isConnected;

        public Client(String ipAddress, int port)
        {
            _client = new TcpClient(ipAddress, port);

            _isConnected = true;
            //HandleCommunication();
        }

        private void HandleCommunication()
        {
            _sr = new StreamReader(_client.GetStream(), Encoding.ASCII);
            _sw = new StreamWriter(_client.GetStream(), Encoding.ASCII);

            _isConnected = true;
            String data = null;

            while (_isConnected)
            {

            }
        }

        public void SendData(string? data)
        {
            if (data == null)
                return;

            _sw = new StreamWriter(_client.GetStream(), Encoding.ASCII);

            if (_isConnected)
            {
                _sw.WriteLine(data);
                _sw.Flush();
            }
        }
    }
}
