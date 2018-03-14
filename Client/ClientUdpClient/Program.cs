using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace ClientUdpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = new byte[1024];
            String message;
            UdpClient client = new UdpClient("127.0.0.1", 9000);
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);

            // yêu cầu kết nối
            bytes = Encoding.ASCII.GetBytes("Request");
            client.Send(bytes, bytes.Length);

            while (true)
            {
                // nhận
                bytes = new byte[1024];
                bytes = client.Receive(ref server);
                message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                Console.WriteLine($"Server: {message}");
                // gửi
                message = Console.ReadLine();
                bytes = Encoding.ASCII.GetBytes(message);
                client.Send(bytes, message.Length);
            }
        }
    }
}
