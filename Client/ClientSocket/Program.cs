using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace ClientSocket
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
            } catch(SocketException e)
            {
                Console.WriteLine("Khong the ket noi");
                Console.WriteLine(e.ToString());
                return;
            }
            while (true)
            {
                // nhận
                bytes = new byte[1024];
                length = client.Receive(bytes);
                message = Encoding.ASCII.GetString(bytes, 0, length);
                Console.WriteLine($"Server: {message}");
                // gửi
                message = Console.ReadLine();
                bytes = Encoding.ASCII.GetBytes(message);
                client.Send(bytes);
            }
        }
    }
}