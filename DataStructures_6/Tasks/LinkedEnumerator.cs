using System.Collections;
using System.Collections.Generic;

namespace Tasks
{
    public struct LinkedEnumerator<T> : IEnumerator<T>, IEnumerator
    {
        private LinkedNode<T> _firstNode;
        private LinkedNode<T> _current;
        private bool _isFirstStep;

        public LinkedEnumerator(LinkedNode<T> firstNode)
        {
            _firstNode = firstNode;
            _current = null;
            _isFirstStep = true;
        }

        public T Current => _current.Value;

        object IEnumerator.Current => _current.Value;

        public bool MoveNext()
        {
            if (_isFirstStep)
            {
                _current = _firstNode;
                _isFirstStep = false;

                return true;
            }

            if (_current == null || _current.Next == null)
            {
                return false;
            }

            _current = _current.Next;

            return true;
        }

        public void Reset()
        {
            _isFirstStep = true;
            _current = null;
        }

        public void Dispose()
        { }
    }
}
