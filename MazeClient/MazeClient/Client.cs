using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace MazeClient
{
    public class Client
    {
        public void Start()
        {
            int port = Int32.Parse(ConfigurationManager.AppSettings.Get("ServerPort"));
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            TcpClient client = new TcpClient();
            while (true)
            {
                try
                {
                    client.Connect(ep);
                    break;
                } catch (SocketException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("You are connected");
            //using (NetworkStream stream = client.GetStream())
            //using (StreamReader reader = new StreamReader(stream))
            //using (StreamWriter writer = new StreamWriter(stream))
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            char[] buf = new char[1000];
            {
                try
                {
                    // Receiving data stream
                    new Task(() =>
                    {
                        while (true)
                        {
                            //Console.WriteLine(reader.ReadBlock(buf, 0, 800));
                           // reader.ReadBlock(buf, 0, 800);
                            Console.WriteLine(reader.ReadLine());
                        }
                    }).Start();
                    while (true)
                    {
                        writer.WriteLine(Console.ReadLine());
                        writer.Flush();
                    }
                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            client.Close();
        }
    }
}