using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace PingLab_Client
{
    class Program
    {
        //private const string HOST = "127.0.0.1";
        //private const int PORT = 1055;
        private static UdpClient udpClient;
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Required arguments: ");
                Console.WriteLine("First: host");
                Console.WriteLine("Second: port");
                return;
            }
            string host = args[0];
            int port = Convert.ToInt32(args[1]);
            Stopwatch stopWatch = new Stopwatch();
            // Create a datagram socket for receiving and sending UDP packets
            // through the host and port specified on the command line.
            udpClient = new UdpClient(host, port);
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReceiveTimeout, 1000); // set timeout

            Console.WriteLine("Client started successfully");
            int count = 0; // sequence number
            // Processing loop. Sending 10 pings
            while (count < 10)
            {
                stopWatch.Start(); // start timer
                sendMessage(count); // send message to server
                receiveMessage(); // receive message from server
                stopWatch.Stop(); // stop timer 
                TimeSpan ts = stopWatch.Elapsed; // get elapsed time
                Console.WriteLine("RTT: " + ts.Seconds + " s and " + ts.Milliseconds + " ms" + "\n");
                stopWatch.Reset(); // reset timer
                count++; // increment count
                Thread.Sleep(1000); // sleep for 1 second before sending next packet to server
            }
        }
        private static void receiveMessage()
        {
            System.Net.IPEndPoint ep = null;
            try
            {
                // Block until the host receives a UDP packet.
                Console.WriteLine("Receiving response from server");
                byte[] rdata = udpClient.Receive(ref ep);
                // Print the recieved data.
                string name_string = Encoding.ASCII.GetString(rdata);
                Console.WriteLine("Just received: " + name_string);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Failed to receive from server. The packet was dropped." + "\n");
            }
        }
        private static void sendMessage(int count)
        {
            try
            {
                // creating data
                string ping = "PING" + " " +
                               count + " " +
                               DateTime.Now + " " +
                               "\r\n";
                byte[] messageInByte = Encoding.ASCII.GetBytes(ping); // convert data to bytes
                Console.WriteLine("Sending message");
                udpClient.Send(messageInByte, messageInByte.Length); // send data to server
                Console.WriteLine("Just sent: " + ping);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to send from client");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
