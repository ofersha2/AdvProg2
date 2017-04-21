using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MazeServer
{
    /// <summary>
    /// Implementation of the View portion of the program:
    /// Passes messages from the clients to the Controller
    /// and vise versa.
    /// </summary>
    class MazeView : View
    {
        /// <summary>
        /// A dictionary assigning each client its own unique ID.
        /// </summary>
        private Dictionary<int, TcpClient> clients = new Dictionary<int, TcpClient>(); 
        /// <summary>
        /// View constructor, same as base.
        /// </summary>
        /// <param name="ctrl">The controller portion of our MVC.</param>
        public MazeView(Controller ctrl) : base(ctrl)
        {

        }
        /// <summary>
        /// Initialize the view: Starts the server and sends
        /// clients to be handled by the handled upon connection.
        /// </summary>
        public override void Start()
        {
            int port = Int32.Parse(ConfigurationManager.AppSettings.Get("ServerPort"));
            IPEndPoint ep = new
            IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            TcpListener listener = new TcpListener(ep);
            listener.Start();
            //Waiting for connections...
            Console.WriteLine("Waiting for connections...");
            while (true)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Got new connection with " + client.GetHashCode());
                    //Add to our client list.
                    this.clients[client.GetHashCode()] = client;
                    new Task(() =>
                    {
                        HandleClient(client);
                    }).Start();
                }
                // In case of disabled connection, stop the server.
                catch (SocketException)
                {
                    break;
                }
            }
            Console.WriteLine("Server stopped");
        }
        /// <summary>
        /// Handles a client, passing its requests onto the controller.
        /// </summary>
        /// <param name="client">The client we are currently handling.</param>
        private void HandleClient(TcpClient client)
        {
            //using (NetworkStream stream = client.GetStream())
            //using (StreamReader reader = new StreamReader(stream))
            //using (StreamWriter writer = new StreamWriter(stream))
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            {
                while (true)
                {
                    try
                    {
                        string cmd = reader.ReadLine();
                        new Task(() =>
                        {
                            controller.CommandHandler(cmd, client.GetHashCode());
                        }).Start();
                    }
                    catch (IOException)
                    {
                        break;
                    }
                }
                client.Close();
            }
        }
        /// <summary>
        /// Displays a message to a connected client.
        /// </summary>
        /// <param name="msg">The message we wish to pass to the client.</param>
        /// <param name="clientId">ID of the client we wish to pass to.</param>
        public override void DisplayToClient(string msg, int clientId)
        {
            //NetworkStream stream = this.clients[clientId].GetStream();
            //using (StreamReader reader = new StreamReader(stream))
            //using (StreamWriter writer = new StreamWriter(stream))
            NetworkStream stream = this.clients[clientId].GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            {
                writer.WriteLine(msg);
                writer.Flush();
            }
        }
    }
}