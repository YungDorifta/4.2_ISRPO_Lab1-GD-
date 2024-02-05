using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LabSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 8081);
                StreamReader reader = new StreamReader(client.GetStream());
                NetworkStream writer = client.GetStream();

                while (true)
                {
                    string dataToServer = Console.ReadLine();
                    dataToServer += "\r\n";

                    byte[] data = Encoding.ASCII.GetBytes(dataToServer);
                    writer.Write(data, 0, data.Length);

                    if (dataToServer.IndexOf("QUIT") > 1) break;
                }

                Console.ReadKey();
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
