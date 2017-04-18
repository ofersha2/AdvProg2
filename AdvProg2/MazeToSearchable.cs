using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchAlgorithmsLib;
using MazeLib;

namespace MazeSolver
{
    class MazeToSearchable : ISearchable
    {
        private Maze maze;
        private State<Position> initial;
        private State<Position> goal;

        public MazeToSearchable(Maze inputMaze)
        {
            this.maze = inputMaze;
            this.initial = new State<Position>(inputMaze.InitialPos);
            this.goal = new State<Position>(inputMaze.GoalPos);
        }

        public List<IState> GetAllPossibleStates(IState state)
        {
            List<IState> neighbors = new List<IState>();
            // Can only handle states befitting maze-type objects.
            if (state.GetState().GetType() != typeof(Position))
            {
                return neighbors;
            }
            Position current = (Position)state.GetState();
            int row = current.Row, col = current.Col;
            // Adding all possible neighbors:
            if (row > 0 && this.maze[row - 1, col] == CellType.Free)
                neighbors.Add(new State<Position>(new Position(row - 1, col), state));
            if (row < this.maze.Rows - 1 && this.maze[row + 1, col] == CellType.Free)
                neighbors.Add(new State<Position>(new Position(row + 1, col), state));
            if (col > 0 && this.maze[row, col - 1] == CellType.Free)
                neighbors.Add(new State<Position>(new Position(row, col - 1), state));
            if (col < this.maze.Cols - 1 && this.maze[row, col + 1] == CellType.Free)
                neighbors.Add(new State<Position>(new Position(row, col + 1), state));
            return neighbors;
        }

        public IState GetGoalState()
        {
            return goal;
        }

        public IState GetInitialState()
        {
            return initial;
        }
    }
}
