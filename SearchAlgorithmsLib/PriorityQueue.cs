using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Implementation of a Priority Queue,
    /// in the form of a minimum heap.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class PriorityQueue<T> : ICollection<T> where T : IComparable
    {
        private List<T> elements;

        int ICollection<T>.Count
        {
            get
            {
                return elements.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public PriorityQueue()
        {
            this.elements = new List<T>();
        }
        public void Add(T item)
        {
            elements.Add(item);
            Sort();
        }
        public bool Remove(T item)
        {
            if (!elements.Contains(item))
                return false;
            int i = elements.IndexOf(item);
            int last = elements.Count - 1;
            elements[i] = elements[last];
            elements.RemoveAt(last);
            Sort();
            return true;
        }
        public T PopTop()
        {
            if (elements.Count == 0)
                throw new InvalidOperationException();
            T item = elements[0];
            int last = elements.Count - 1;
            elements[0] = elements[last];
            elements.RemoveAt(last);
            Sort();
            return item;
        }
        public void Sort()
        {
            for (int i = elements.Count - 1; i > 0; i--)
            {
                int parentPosition = (i + 1) / 2 - 1;
                parentPosition = parentPosition >= 0 ? parentPosition : 0;

                if (elements[parentPosition].CompareTo(elements[i]) >= 1)
                {
                    T temp = elements[parentPosition];
                    elements[parentPosition] = elements[i];
                    elements[i] = temp;
                }
            }
        }
        public bool Contains(T element)
        {
            return this.elements.Contains(element);
        }
        public int Count()
        {
            return elements.Count();
        }
        public int IndexOf(T element)
        {
            return this.elements.LastIndexOf(element);
        }
        public T ElementAt(int i)
        {
            return this.elements[i];
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.elements.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.elements.AsEnumerable<T>().GetEnumerator();
        }
    }
}
