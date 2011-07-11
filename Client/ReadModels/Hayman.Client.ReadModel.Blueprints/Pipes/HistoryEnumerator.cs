using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hayman.MetaStudio.Core.Pipes
{
    public class HistoryEnumerator<T> : IEnumerator<T>
    {
        private readonly IEnumerator<T> _enumerator;

        public HistoryEnumerator(IEnumerator<T> enumerator)
        {
            _enumerator = enumerator;
        }

        public void Dispose()
        {
            _enumerator.Dispose();
        }

        public bool MoveNext()
        {
            return _enumerator.MoveNext();
        }

        public void Reset()
        {
            _enumerator.Reset();
        }

        public T Current
        {
            get { return _enumerator.Current; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
