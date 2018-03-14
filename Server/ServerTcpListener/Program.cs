using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace ServerTcpListener
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = new byte[1024];
            int length;
            String message;

            TcpListener server = new TcpListener(9000);
            server.Start();

            Console.WriteLine("dang cho ket noi");
            TcpClient client = server.AcceptTcpClient();
            NetworkStream ns = client.GetStream();

            message = "ket noi thanh cong";
            Console.WriteLine(message);
            bytes = Encoding.ASCII.GetBytes(message);
            ns.Write(bytes, 0, message.Length);
            ns.Flush();

            while (true)
            {
                // nhận
                length = ns.Read(bytes, 0, bytes.Length);
                if (length == 0) break;
                message = Encoding.ASCII.GetString(bytes, 0, length);
                Console.WriteLine($"Client: {message}");

                // gửi
                ns.Write(bytes, 0, message.Length);
                ns.Flush();
            }
            ns.Close();
            client.Close();
        }
    }
}
