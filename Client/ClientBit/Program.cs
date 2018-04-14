using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace ClientBit
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = new byte[1024];
            String message;

            UdpClient client = new UdpClient("127.0.0.1", 9000);

            IPEndPoint server = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);

            message = "connecting";
            bytes = Encoding.ASCII.GetBytes(message);
            client.Send(bytes, message.Length);

            bytes = client.Receive(ref server);
            message = Encoding.ASCII.GetString(bytes);
            Console.WriteLine($"server: {message}");
            while (true)
            {

            }
        }
    }
}
