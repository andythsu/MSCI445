using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace PingLab_Server
{
    class Program
    {
        private const double LOSS_RATE = 0.3;
        private const double AVG_DELAY = 100; // milliseconds
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Required arguments: port");
                return;
            }
            int port = Convert.ToInt32(args[0]);
            IPEndPoint localpt = new IPEndPoint(IPAddress.Any, port);
            // Create random number generator for use in simulating
            // packet loss and network delay.
            Random random = new Random();
            // Create a datagram socket for receiving and sending UDP packets
            // through the port specified on the command line.
            UdpClient socket = new UdpClient();
            socket.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            socket.Client.Bind(localpt);
            System.Net.IPEndPoint ep = null;

            Console.WriteLine("Server started successfully");

            // Processing loop.
            while (true)
            {
                // Block until the host receives a UDP packet.
                byte[] rdata = socket.Receive(ref ep);
                Console.WriteLine("Received UDP data");
                // Print the recieved data.
                string name_string = Encoding.ASCII.GetString(rdata);
                Console.WriteLine("Just received: " + name_string);

                // Decide whether to reply, or simulate packet loss.
                if (random.NextDouble() < LOSS_RATE)
                {
                    Console.WriteLine(" Reply not sent.");
                    continue;
                }
                // Simulate network delay.
                Thread.Sleep((int)(random.NextDouble() * 2 * AVG_DELAY));
                // Send reply.
                socket.Send(rdata, rdata.Length, ep);
                Console.WriteLine(" Reply sent.");
            }
        }
    }
}
