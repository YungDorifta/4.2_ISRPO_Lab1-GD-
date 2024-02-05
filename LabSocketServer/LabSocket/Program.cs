using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.IO;

namespace LabSocketServer
{
    class Program
    {
        //part A
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(8081);
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            StreamReader reader = new StreamReader(client.GetStream());
            NetworkStream writer = client.GetStream();
            
            string dataFromClient = reader.ReadLine();
            Console.WriteLine(dataFromClient);
            //if (dataFromClient.IndexOf("QUIT") > 1) break;

            /*
            string dataToBrowser = "HTTP/1.1 200 OK\n" +
                "Date: Wed, 11 Feb 2009 11:20:59 GMT\n" +
                "Server: Apache\n" +
                "Last-Modified: Wed, 11 Feb 2021 11:20:59 GMT\n" +
                "Content-Type: text/html; charset=utf-8\n" +
                "\r\n\r\n" +
                "<!Doctype html>\n" +
                "<html>\n" +
                "<body>\n" +
                "<h1>My First Heading</h1>\n" +
                "<p>My First Paragraph.</p>\n" +
                "</body>\n" +
                "</html>\r\n" + Environment.NewLine;
            byte[] dataWrite = Encoding.ASCII.GetBytes(dataToBrowser);
            writer.Write(dataWrite, 0, dataWrite.Length);
            */

            Console.ReadKey();
            client.Close();
            listener.Stop();
        }
    }
}
