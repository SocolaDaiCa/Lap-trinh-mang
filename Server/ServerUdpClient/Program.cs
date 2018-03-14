using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace ServerUdpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = new byte[1024];
            String mesage;
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 9000);
            UdpClient server = new UdpClient(ipe);

            Console.WriteLine("dang cho ket noi");
            // chờ kết nối
            IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
            bytes = server.Receive(ref client);
            mesage = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
            Console.WriteLine($"Client: {mesage}");
            bytes = Encoding.ASCII.GetBytes("Da ket noi");
            server.Send(bytes, bytes.Length, client);

            // lấy thông tin client
            Console.WriteLine($"Ket noi voi {client.Address} cong {client.Port}");
            mesage = "ket noi thanh cong";
            bytes = Encoding.ASCII.GetBytes(mesage);
            server.Send(bytes, mesage.Length, client);

            while (true)
            {
                // nhận
                bytes = new byte[2014];
                bytes = server.Receive(ref client);
                mesage = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                // gửi
                Console.WriteLine($"Client: {mesage}");
                server.Send(bytes, mesage.Length, client);
            }
        }
    }
}
