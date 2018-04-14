using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace serverx
{
    class Program
    {
        static void Main(string[] args)
        {
            // client
            byte[] bytes = new byte[1024];
            String message;
            UdpClient client = new UdpClient("127.0.0.1", 9000);
            IPEndPoint server = new IPEndPoint(IPAddress.Any, 0);

            // yêu cầu kết nối
            bytes = Encoding.ASCII.GetBytes("Request");
            client.Send(bytes, bytes.Length);
            bytes = client.Receive(ref server);
            message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
            Console.WriteLine($"Server: {message}");
            // chào
            bytes = Encoding.ASCII.GetBytes("chao server");
            client.Send(bytes, bytes.Length);
            bytes = client.Receive(ref server);
            message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
            Console.WriteLine($"Server: {message}");

            while (true)
            {
                // gui a, b
                message = Console.ReadLine();
                bytes = Encoding.ASCII.GetBytes(message);
                client.Send(bytes, bytes.Length);
                // nhan
                bytes = client.Receive(ref server);
                message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                Console.WriteLine($"Server: {message}");
                // dong y lam nua
                bytes = client.Receive(ref server);
                message = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                Console.WriteLine($"Server: {message}");

                message = Console.ReadLine();
                bytes = Encoding.ASCII.GetBytes(message);
                client.Send(bytes, bytes.Length);
                if (message == "khong") break;
                
            }
        }
    }
}
