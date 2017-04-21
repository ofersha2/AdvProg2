using MazeServer.Model.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;


namespace MazeServer
{
    class MazeController : Controller
    {
        private Dictionary<string, MazeCommand> commands;

        public override void CommandHandler(string commandString, int clientID)
        {
            string msg = (new MazeGeneratorLib.DFSMazeGenerator()).Generate(20, 20).ToJSON();
            Console.WriteLine(msg);
            this.View.DisplayToClient(msg, clientID);
        }
    }
}