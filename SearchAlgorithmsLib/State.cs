using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// This class defines the current state of a given puzzle,
    /// as a step towards solving it.
    /// For example, for a maze, a state could be defined
    /// as the current coordinates of the player as they 
    /// attempt to traverse it.
    /// </summary>
    /// <typeparam name="T">The field with which we actively define the puzzle state.</typeparam>
    class State<T> : IState where T : ICloneable
    {
        /// <summary>
        /// This field actively defining the current state of the puzzle.
        /// </summary>
        private T state;

        /// <summary>
        /// All states can be traced down to the very first state of the puzzle,
        /// via one's "parent".
        /// </summary>
        public IState CameFrom { get; set; }

        /// <summary>
        /// The cost of traversing the puzzle thus far. Puzzle-reliant property.
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Default constructor, assuming "brand new" state, no tracebacks.
        /// </summary>
        /// <param name="state">The field actively defining the current state.</param>
        public State(T state)
        {
            this.state = state;
            this.CameFrom = null;
            this.Cost = 0;
        }

        /// <summary>
        /// Parent-dependant constructor.
        /// </summary>
        /// <param name="state">The field actively defining the current state.</param>
        /// <param name="parent">The state from which we arrived to this one.</param>
        public State(T state, IState parent)
        {
            this.state = state;
            this.CameFrom = parent;
            this.Cost = 1 + parent.Cost;
        }

        /// <summary>
        /// Cost-based constructor
        /// </summary>
        /// <param name="state">The field actively defining the current state.</param>
        /// <param name="cost">The cost of reaching this current state.</param>
        public State(T state, double cost)
        {
            this.state = state;
            this.CameFrom = null;
            this.Cost = cost;
        }
        /// <summary>
        /// Returns a copy of the actual state.
        /// Note that it is an object and not T for hereditary reasons.
        /// </summary>
        /// <returns>A cloned version of the state's defining field.</returns>
        public object GetState()
        {
            return state.Clone();
        }
        /// <summary>
        /// We override Object's Equals method based on the state implementation.
        /// </summary>
        /// <param name="obj">The object (hopefully another state) we wish to compare to.</param>
        /// <returns>True if the two objects have an equal state field, false otherwise.</returns>
        public override bool Equals(object obj) // 
        {
            if (!(obj is IState))
            {
                return false;
            }
            return state.Equals((obj as IState).GetState());
        }
        /// <summary>
        /// We override the HashCode based on the state's defining trait.
        /// </summary>
        /// <returns>The state's hash code.</returns>
        public override int GetHashCode()
        {
            return state.GetHashCode();
        }

        /// <summary>
        /// We compare states by the cost it took to reach each one.
        /// </summary>
        /// <param name="obj">The object (hopefully another state) we wish to compare with.</param>
        /// <returns>Negative if this instance is of lesser cost, zero if costs are equal,
        /// positive otherwise.</returns>
        public int CompareTo(object obj)
        {
            if (!(obj is IState))
            {
                throw new ArgumentException();
            }
            IState other = obj as IState;
            return (this.Cost.CompareTo(other.Cost));
        }

        /// <summary>
        /// The State's defining trait is its "state" field,
        /// which is how we represent this object in string-form.
        /// </summary>
        /// <returns>A string representation of this current state.</returns>
        public override string ToString()
        {
            return state.ToString();
        }

    }
}
