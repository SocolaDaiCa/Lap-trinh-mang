using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ClientSocketNetworkStream
{
    class Program
    {
        static void Main(string[] args)
        {
            int length;
            byte[] bytes = new byte[1024];
            String message;
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);
            try
            {
                client.Connect(ipe);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Khong the ket noi");
                Console.WriteLine(e.ToString());
                return;
            }
            NetworkStream ns = new NetworkStream(client);
            //StreamReader reader = new StreamReader(ns);
            //StreamWriter writer = new StreamWriter(ns);

            while (true)
            {
                // nhận
                bytes = new byte[1024];
                length = ns.Read(bytes, 0, bytes.Length);
                message = Encoding.ASCII.GetString(bytes, 0, length);
                Console.WriteLine($"Server: {message}");
                // gửi
                message = Console.ReadLine();
                bytes = Encoding.ASCII.GetBytes(message);
                ns.Write(bytes, 0, message.Length);
                ns.Flush();
            }
        }
    }
}
