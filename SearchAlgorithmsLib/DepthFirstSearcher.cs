using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Implementation of a recursive DFS searcher.
    /// </summary>
    class DepthFirstSearcher : Searcher
    {
        /// <summary>
        /// Base constructor from core Searcher class.
        /// </summary>
        public DepthFirstSearcher() : base()
        {
        }
        /// <summary>
        /// Search in accordance to algorithm: Mark each node we traverse,
        /// check if it's the solution - otherwise, traverse its neighbors.
        /// </summary>
        /// <param name="searchable">The "puzzle" we wish to solve.</param>
        /// <returns>The solution found to the puzzle according to our DFS algorithm.</returns>
        public override ISolution Search(ISearchable searchable)
        {
            IState start = searchable.GetInitialState();
            return DFS(start, searchable);
        }
        /// <summary>
        /// Auxiliary method for the recursive portion of the DFS
        /// </summary>
        /// <param name="state">The current state we traverse/</param>
        /// <param name="searchable">The "puzzle" we wish to solve.</param>
        /// <returns>The solution found to the puzzle according to our DFS algorithm.</returns>
        private ISolution DFS(IState state, ISearchable searchable)
        {
            // "label v as discovered"
            this.AddToOpenList(state);
            // If we found our goal state, we stop.
            if (state.Equals(searchable.GetGoalState()))
                return this.backTrace(state);
            // "for all edges from v to w..."
            List<IState> successors = searchable.GetAllPossibleStates(state);
            foreach (IState neighbor in successors)
                // "if w is not labeled discovered then recursively call DFS(G, w)"
                if (!this.OpenContains(neighbor))
                {
                    ISolution sol = DFS(neighbor, searchable);
                    // The solution, once found, is passed backwards to the recursion root.
                    if (sol != null)
                        return sol;
                }
            // Non-solution branches return null once traversed.
            return null;
        }
    }
}
