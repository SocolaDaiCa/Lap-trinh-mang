using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace clientx
{
    class Program
    {
        static void Main(string[] args)
        {
            //server
            Console.WriteLine("dang cho ket noi");
            byte[] bytes = new byte[1024];
            String mesage;
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 9000);
            server.Bind(ipe);
            
            IPEndPoint ipeNhan = new IPEndPoint(IPAddress.Any, 0);
            EndPoint client = (EndPoint)ipeNhan;

            

            // ket noi thanh cong
            int length = server.ReceiveFrom(bytes, ref client);
            mesage = Encoding.ASCII.GetString(bytes, 0, length);
            Console.WriteLine($"Client: {mesage}");
            bytes = Encoding.ASCII.GetBytes("ket noi thanh cong");
            server.SendTo(bytes, client);
            // gui ?
            length = server.ReceiveFrom(bytes, ref client);
            mesage = Encoding.ASCII.GetString(bytes, 0, length);
            Console.WriteLine($"Client: {mesage}");
            bytes = Encoding.ASCII.GetBytes("?");
            server.SendTo(bytes, client);
            while (true)
            {
                // nhan
                bytes = new byte[1024];
                length = server.ReceiveFrom(bytes, ref client);
                mesage = Encoding.ASCII.GetString(bytes, 0, length);
                Console.WriteLine($"Client: {mesage}");
                String[] arr = mesage.Split(';');
                int a = int.Parse(arr[0]);
                int b = int.Parse(arr[1]);
                bytes = Encoding.ASCII.GetBytes((a+b).ToString());
                server.SendTo(bytes, client);
                // hoi lam nua
                bytes = Encoding.ASCII.GetBytes("lam nua khong");
                server.SendTo(bytes, client);
                bytes = new byte[1024];
                length = server.ReceiveFrom(bytes, ref client);
                mesage = Encoding.ASCII.GetString(bytes, 0, length);
                Console.WriteLine($"Client: {mesage}");
                if (mesage == "khong") break;
            }
        }
    }
}
