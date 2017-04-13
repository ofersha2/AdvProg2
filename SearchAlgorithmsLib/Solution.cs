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
    }
}
