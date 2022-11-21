using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TeacherClient
{
    internal class Client
    {
        private static Client instance;
        private static readonly object padlock = new object();

        public static Client Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Client("127.0.0.1", 5555);
                    }
                    return instance;
                }
            }
        }

        private TcpClient _client;

        private StreamReader _sr;
        private StreamWriter _sw;

        private bool _isConnected;

        public Client(String ipAddress, int port)
        {
            _client = new TcpClient(ipAddress, port);

            _isConnected = true;
        }

        public List<string> SendData(string? data)
        {
            if (data == null)
                return null;

            _sw = new StreamWriter(_client.GetStream(), Encoding.ASCII);
            _sr = new StreamReader(_client.GetStream(), Encoding.ASCII);

            if (_isConnected)
            {
                _sw.WriteLine(data);
                _sw.Flush();

                List<string> response = new List<string>();
                while (_sr.Peek() != -1)
                {
                    response.Add(_sr.ReadLine() ?? "");
                }
                return response;
            }

            return null;
        }

        public void CloseConnection()
        {
            _client.Close();
        }
    }
}
