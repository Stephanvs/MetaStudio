using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Hayman.MetaStudio.Core.Pipes
{
    public abstract class Pipe<TStart, TEnd> :
        IPipe<TStart, TEnd> where TStart : IComparable<TStart> where TEnd : IComparable<TEnd>
    {
        protected Pipe()
        {
            current = default(TEnd);
        }

        protected IEnumerator<TStart> starts;

        public void Starts(IEnumerator<TStart> s)
        {
            //if (s is IPipe)
                starts = s;
            //else
            //    starts = new HistoryEnumerable<TStart>(s);
        }

        public void Starts(IEnumerable<TStart> elements)
        {
            Starts(elements.GetEnumerator());
        }

        public ArrayList GetPath()
        {
            var pathElements = GetPathToHere();
            var size = pathElements.Count;

            if (size == 0 || !(pathElements[size - 1].Equals(starts.Current)))
            {
                pathElements.Add(starts.Current);
            }
            return pathElements;
        }

        protected abstract TEnd ProcessNextStart();

        protected ArrayList GetPathToHere()
        {
            if (starts is IPipe) {
                return ((IPipe)starts).GetPath();
            }
            
            if (starts is HistoryEnumerator<TStart>)
            {
                return new ArrayList() { new HistoryEnumerator<TStart>(starts) };
            }

            return new ArrayList();
        }

        #region IEnumerator<T> implementation

        protected TEnd current;

        public bool MoveNext()
        {
            if (!starts.MoveNext()) return false;

            current = ProcessNextStart();
            return true;
        }

        public void Reset()
        {
            current = default(TEnd);
        }

        void IDisposable.Dispose()
        {

        }

        public TEnd Current
        {
            get { return current; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        #endregion

        #region IEnumerable<T> implementation

        public IEnumerator<TEnd> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
