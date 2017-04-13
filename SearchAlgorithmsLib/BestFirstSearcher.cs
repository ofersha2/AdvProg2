using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Implementation of a BestFirstSearcher algorithm using
    /// an open and closed lists.
    /// </summary>
    class BestFirstSearcher : Searcher
    {
        /// <summary>
        /// Base constructor taken from core Searcher class
        /// </summary>
        public BestFirstSearcher() : base()
        {
        }
        /// <summary>
        /// Search in accordance to algorithm, followed step by step.
        /// </summary>
        /// <param name="searchable">The "puzzle" which we search through.</param>
        /// <returns>The solution found to the puzzle according to our BFS algorithm.</returns>
        public override ISolution Search(ISearchable searchable)
        {

            this.AddToOpenList(searchable.GetInitialState()); // inherited from Searcher
            HashSet<IState> closed = new HashSet<IState>();
            while (OpenListSize > 0)
            {
                IState state = PopOpenList();  // inherited from Searcher, removes the best state
                closed.Add(state);
                if (state.Equals(searchable.GetGoalState()))
                    return this.backTrace(state); // private method, back traces through the parents
                                                  // calling the delegated method, returns a list of states with n as a parent
                List<IState> successors = searchable.GetAllPossibleStates(state);
                foreach (IState s in successors)
                {
                    if (!closed.Contains(s) && !this.OpenContains(s))
                    {
                        // s.setCameFrom(n);  // already done by getSuccessors
                        this.AddToOpenList(s);
                    }
                    else
                    {
                        //Checking to see if this path is better than an existing one.
                        if (this.OpenContains(s))
                        {
                            int i = this.OpenIndexOf(s);
                            double currentCost = this.OpenElementAt(i).Cost;
                            //This path is indeed better
                            if (s.Cost < currentCost)
                            {
                                this.OpenRemoveElement(s);
                                this.AddToOpenList(s);
                            }
                        }
                    }
                }
            }
            return null; // no solution found
        }
    }
}

