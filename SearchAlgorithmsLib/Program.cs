using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            MatrixMaze maze = (new PrimMatrixMazeFactory()).Build(size);
            Console.WriteLine(maze.ToString());
            string command = Console.ReadLine();
            bool done = false;
            while (command != "q" && !done)
            {
                if (command.Equals("u"))
                    done = maze.MoveUp();
                if (command.Equals("d"))
                    done = maze.MoveDown();
                if (command.Equals("l"))
                    done = maze.MoveLeft();
                if (command.Equals("r"))
                    done = maze.MoveRight();
                Console.WriteLine(maze.ToString());
                command = Console.ReadLine();
            }  
            ISearcher searcher = new DepthFirstSearcher();
            ISolution sol = searcher.Search(maze);
            Console.WriteLine(sol.ToString());
            Console.ReadLine();
            List<Point> sols = (sol as Solution).SolImprint();
            char[][] matrix = maze.maze();
            matrix[sols[0].Row][sols[0].Col] = '2';
            for (int i = 1; i < sols.Count; i++)
            {
                matrix[(sols[i - 1].Row + sols[i].Row) / 2][(sols[i - 1].Col + sols[i].Col) / 2] = '2';
                matrix[sols[i].Row][sols[i].Col] = '2';
            }
            matrix[sols[sols.Count - 1].Row][sols[sols.Count - 1].Col] = '*';

            StringBuilder str = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].GetLength(0); j++)
                {
                    str.Append(matrix[i][j]);
                }
                if (i < matrix.GetLength(0) - 1)
                    str.Append('\n');
            }
            Console.WriteLine(str.ToString());
            Console.ReadLine();
        }
    }
}
