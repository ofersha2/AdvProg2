using System;

namespace MazeServer
{
    abstract class Controller
    {
        public View View { get; set; }
        public Model Model { get; set; }
        public abstract void CommandHandler(string commandString, int clientID);
    }
}