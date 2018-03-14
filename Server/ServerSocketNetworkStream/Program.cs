using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace ServerSocketNetworkStream
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = new byte[1024];
            int length;
            String mesage;
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 9000);
            server.Bind(ipe);
            server.Listen(10);
            Console.WriteLine("dang cho ket noi");
            // chấp nhận kết nối
            Socket connect = server.Accept();
            NetworkStream ns = new NetworkStream(connect);

            // lấy thông tin client
            IPEndPoint clientInfo = (IPEndPoint)connect.RemoteEndPoint;
            Console.WriteLine($"Ket noi voi {clientInfo.Address} cong {clientInfo.Port}");
            mesage = "ket noi thanh cong";
            bytes = Encoding.ASCII.GetBytes(mesage);
            ns.Write(bytes, 0, mesage.Length);
            ns.Flush();

            while (true)
            {
                // nhận
                bytes = new byte[2014];
                length = connect.Receive(bytes);
                mesage = Encoding.ASCII.GetString(bytes, 0, length);
                // gửi
                Console.WriteLine($"Client: {mesage}");
                ns.Write(bytes, 0, mesage.Length);
                ns.Flush();
            }
        }
    }
}
