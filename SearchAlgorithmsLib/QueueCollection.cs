using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// An extension/adapter of C#'s generic Queue,
    /// which allows it to count as a Collection.
    /// </summary>
    /// <typeparam name="T">T is the Comparable, Enumerable type of data in the Queue.</typeparam>
    class QueueCollection<T> : Queue<T>, ICollection<T>
    {
        /// <summary>
        /// "Read Only" property of the Collection - false,
        /// as the queue is modifyable via its enqueue/dequeue methods.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Translating the Enqueue method into a generic,
        /// Collection-fitted form.
        /// </summary>
        /// <param name="item">The item we wish to add to the Queue.</param>
        public void Add(T item)
        {
            this.Enqueue(item);
        }
        /// <summary>
        /// Attempt to remove a specific item from the Queue,
        /// O(n), as the data structure does not normally support this method.
        /// </summary>
        /// <param name="item">The item we wish to try to remove.</param>
        /// <returns>True if said item was found and removed, false otherwise.</returns>
        public bool Remove(T item)
        {
            bool found = false;
            Queue<T> temp = new Queue<T>();
            T head;
            while (this.Count > 0)
            {
                head = this.Dequeue();
                if (head.Equals(item))
                {
                    found = true;
                }
                else {
                    temp.Enqueue(this.Dequeue());
                }
            }
            while (temp.Count > 0)
            {
                this.Enqueue(temp.Dequeue());
            }
            return found;
        }
    }
}
