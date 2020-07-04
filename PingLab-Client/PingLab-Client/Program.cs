using System;
using System.Net.Sockets;

namespace PingLab_Client
{
    class Program
    {
        private const string HOST = "127.0.0.1";
        private const int PORT = 1055;

        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient(HOST, PORT);
            int n = 10;
            for (int i = 0; i < n; i++)
            {
                string payload = "PING" + " " + i + " " + DateTime.Now.ToString() + "\r\n";
                Console.WriteLine(payload);
            }
        }
    }
}
