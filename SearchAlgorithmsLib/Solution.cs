using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    class Solution : ISolution
    {
        private List<IState> path;
        public Solution(List<IState> path)
        {
            this.path = path;
        }
        public override string ToString()
        {
            return string.Join(",", path);
        }

        public List<Point> SolImprint()
        {
            List<Point> sols = new List<Point>();
            for (int i = 0; i < path.Count; i++)
                sols.Add(path[i].GetState() as Point);
            return sols;
        }
    }
}
