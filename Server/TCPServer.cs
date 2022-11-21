using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class TCPServer
    {
        private TcpListener _server;
        private bool _isRunning;

        public TCPServer(int port)
        {
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();

            _isRunning = true;

            Console.WriteLine("Server Started");

            LoopClients();
        }

        private void LoopClients()
        {
            while (_isRunning)
            {
                TcpClient tcpClient = _server.AcceptTcpClient();

                Thread thread = new Thread(new ParameterizedThreadStart(HandleClient));
                thread.Start(tcpClient);
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;

            StreamWriter sw = new StreamWriter(client.GetStream(), Encoding.ASCII);
            StreamReader sr = new StreamReader(client.GetStream(), Encoding.ASCII);

            bool isClientConnected = true;
            string? data = null;

            while (isClientConnected)
            {
                data = sr.ReadLine();

                Console.WriteLine(data);

                RequestHandler.HandleRequest(client, data ?? "");
            }
        }
    }
}
