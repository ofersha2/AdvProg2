using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    interface ISearchable
    {
        IState GetInitialState();
        IState GetGoalState();
        List<IState> GetAllPossibleStates(IState state);
    }
}
