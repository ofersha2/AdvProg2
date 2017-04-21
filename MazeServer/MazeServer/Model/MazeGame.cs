using MazeLib;
using System.Collections.Generic;

namespace MazeServer
{
    class MazeGame
    {
        /// <summary>
        /// The player list.
        /// </summary>
        private List<string> players;
        /// <summary>
        /// The maze map used.
        /// </summary>
        private Maze maze;
        /// <summary>
        /// The game's name (currently identical to the maze's).
        /// </summary>
        private string name;
    }
}