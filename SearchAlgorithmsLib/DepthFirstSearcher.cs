using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    class DepthFirstSearcher : Searcher
    {
        public DepthFirstSearcher() : base()
        {
        }

        public override ISolution Search(ISearchable searchable)
        {
            IState start = searchable.GetInitialState();
            this.AddToOpenList(searchable.GetInitialState());
            if (start.Equals(searchable.GetGoalState) {

            }
            HashSet<IState> ds = new HashSet<IState>();
            while (OpenListSize > 0)
            {
                IState state = PopOpenList();
                closed.Add(state);
                if (state.Equals(searchable.GetGoalState()))
                {
                    return this.backTrace(state);
                }
                List<IState> successors = searchable.GetAllPossibleStates(state);
                foreach (IState s in successors)
                {
                    if (!closed.Contains(s) && !this.OpenContains(s))
                    {
                        // s.setCameFrom(n);  // already done by getSuccessors
                        this.AddToOpenList(s);
                    }
                }
            }
            return null;
        }
        protected override IState PopOpenList()
        {
            evaluatedNodes++;
            return (this.openList as Queue<IState>).Dequeue();
        }

    }
}
