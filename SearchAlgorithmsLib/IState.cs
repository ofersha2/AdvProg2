using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// A class defining a given state of a puzzle.
    /// This allows for documentation of the steps
    /// taking to solve it.
    /// </summary>
    interface IState : IComparable
    {
        /// <summary>
        /// The "cost" of getting to this current state.
        /// </summary>
        double Cost
        {
            get;
            set;
        }
        /// <summary>
        /// The state from which we arrived to this instance.
        /// </summary>
        IState CameFrom
        {
            get;
            set;
        }
        /// <summary>
        /// The actual state is based on the puzzle's implementation,
        /// and can be anything from a string, to a point, to a new object altogether.
        /// </summary>
        /// <returns>The comparable, "workable" value of this instance's state.</returns>
        object GetState();
    }
}
