using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;

namespace MazeSolver
{
    class Program
    {
        static void CompareSolvers()
        {
            DFSMazeGenerator mazeGen = new DFSMazeGenerator();
            Maze maze = mazeGen.Generate(100, 100);
            Console.WriteLine(maze.ToString());
            BestFirstSearcher bfsSrch = new BestFirstSearcher();
            DepthFirstSearcher dfsSrch = new DepthFirstSearcher();
            ISearchable searchableMaze = new MazeToSearchable(maze);
            bfsSrch.Search(searchableMaze);
            dfsSrch.Search(searchableMaze);
            Console.WriteLine("BFS solved in: " + bfsSrch.GetNumberOfNodesEvaluated());
            Console.WriteLine("DFS solved in: " + dfsSrch.GetNumberOfNodesEvaluated());
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            CompareSolvers();
        }
    }
}
