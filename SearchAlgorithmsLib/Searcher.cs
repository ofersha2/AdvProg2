using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    abstract class Searcher : ISearcher
    {
        private PriorityQueue<IState> openList;
        private int evaluatedNodes;

        public Searcher()
        {
            evaluatedNodes = 0;
        }

        protected int OpenListSize
        {
            get { return openList.Count(); }
        }

        protected bool OpenContains(IState state)
        {
            return this.openList.Contains(state);
        }

        protected void AddToOpenList(IState state)
        {
            this.openList.Add(state);
        }

        protected IState OpenElementAt(int i)
        {
            return this.openList.ElementAt(i);
        }

        protected void OpenRemoveElement(IState s)
        {
            this.openList.Remove(s);
        }

        protected IState PopOpenList()
        {
            evaluatedNodes++;
            return this.openList.PopTop();
        }

        protected Solution backTrace(IState final)
        {
            List<IState> path = new List<IState>();
            IState state = final;
            while (state != null)
            {
                path.Add(state);
                state = state.CameFrom;
            }
            path.Reverse();
            return new Solution(path);
        }

        protected int OpenIndexOf(IState s)
        {
            return this.openList.IndexOf(s);
        }

        // ISearcher’s methods:

        public virtual int GetNumberOfNodesEvaluated()
        {
            return this.evaluatedNodes;
        }

        public abstract ISolution Search(ISearchable searchable);
    }
}
