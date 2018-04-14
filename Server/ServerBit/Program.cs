using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace ServerBit
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = new byte [1024];
            String message;

            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 9000);
            UdpClient server = new UdpClient(ipe);

            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);

            bytes = server.Receive(ref client);
            message = Encoding.ASCII.GetString(bytes);
            Console.WriteLine($"client: ${message}");

            message = "connected";
            bytes = Encoding.ASCII.GetBytes(message);
            server.Send(bytes, bytes.Length, client);

            while (true)
            {

            }
        }
    }
}
