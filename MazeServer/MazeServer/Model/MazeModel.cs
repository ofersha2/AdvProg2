using MazeGeneratorLib;
using MazeLib;
using System.Collections.Generic;

namespace MazeServer
{
    class MazeModel : Model
    {
        IMazeGenerator mazeGenerator;
        /// <summary>
        /// List of the mazes, mapped by name.
        /// </summary>
        private Dictionary<string, Maze> mazes;
        /// <summary>
        /// Dictionary of maze solutions.
        /// </summary>
        private Dictionary<string, string> mazeSolutions;
        /// <summary>
        /// Active maze games taking place.
        /// </summary>
        private Dictionary<string, MazeGame> games;

        public MazeModel(Controller ctrl) : base(ctrl)
        {
            this.mazeGenerator = new DFSMazeGenerator();
        }
        public void AddMaze(Maze maze)
        {

        }
        public Maze GetMaze(string mazeName)
        {

        }
        public string SolveMaze(string mazeName)
        {

        }
        public void InitiateGame(string mazeName, string player1)
        {

        }
        public string JoinGame(string mazeName, string player2)
        {

        }
        public string EndGame(string gameName)
        {

        }
    }
}