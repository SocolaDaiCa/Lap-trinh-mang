using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace ClientTCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int length;
            byte[] bytes = new byte[1024];
            String message;
            TcpClient server;
            try
            {
                server = new TcpClient("127.0.0.1", 9000);
            }
            catch (SocketException)
            {
                Console.WriteLine("Ket noi that bai");
                return;
            }
            NetworkStream ns = server.GetStream();

            while (true)
            {
                // nhận
                length = ns.Read(bytes, 0, bytes.Length);
                message = Encoding.ASCII.GetString(bytes, 0, length);
                Console.WriteLine($"Server: {message}");

                // gửi
                message = Console.ReadLine();
                if (message == "exit") break;
                bytes = Encoding.ASCII.GetBytes(message);
                ns.Write(bytes, 0, message.Length);
                ns.Flush();
            }
            ns.Close();
            server.Close();
        }
    }
}
