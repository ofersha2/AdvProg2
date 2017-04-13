using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// A two-dimensional vector used for matrix-iterating,
    /// hence has row and column properties instead of x and y.
    /// </summary>
    class Point : ICloneable
    {
        /// <summary>
        /// Current row of a matrix (downwards-pointing y)
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// Current column of a matrix (right-pointing x)
        /// </summary>
        public int Col { get; set; }

        /// <summary>
        /// Main constructor, each coordinate passed as argument
        /// </summary>
        /// <param name="row">Row value of the point/cell</param>
        /// <param name="column">Column value of the point/cell</param>
        public Point(int row, int column)
        {
            this.Row = row;
            this.Col = column;
        }

        /// <summary>
        /// Compares two points by their coordinate properties.
        /// </summary>
        /// <param name="obj">The object (hopefully a point) we wish to compare to.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                Point pt = obj as Point;
                return (Row == pt.Row && Col == pt.Col);
            }
            return false;
        }

        /// <summary>
        /// Overriding the hash code method to account,
        /// to account for the two-integer coordinates.
        /// </summary>
        /// <returns>A hash code appropriate for this point.</returns>
        public override int GetHashCode()
        {
            // Rather basic hashing method for two integers.
            // That being said, arbitary prime numbers are arbitrary.
            int hash = 17 * 23;
            hash += Row.GetHashCode();
            return (hash * 23 + Col.GetHashCode());
        }
        
        /// <summary>
        /// Overriding the string method to a simple vector representation.
        /// </summary>
        /// <returns>("row", "column")</returns>
        public override string ToString()
        {
            return "(" + Row + "," + Col + ")";
        }

        /// <summary>
        /// Clones this point.
        /// </summary>
        /// <returns>A new Point with the same coordinates as this instance.</returns>
        public object Clone()
        {
            return new Point(this.Row, this.Col);
        }
    }
}
