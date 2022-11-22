using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private IDoublyLinkedList<T> _source;

        public HybridFlowProcessor()
        {
            _source = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            if (_source.Length == 0)
            {
                throw new InvalidOperationException("Source is empty.");
            }

            var item = _source.ElementAt(0);
            _source.RemoveAt(0);

            return item;
        }

        public void Enqueue(T item)
        {
            _source.Add(item);
        }

        public T Pop()
        {
            if (_source.Length == 0)
            {
                throw new InvalidOperationException("Source is empty.");
            }

            var item = _source.ElementAt(_source.Length - 1);
            _source.RemoveAt(_source.Length - 1);

            return item;
        }

        public void Push(T item)
        {
            _source.AddAt(_source.Length, item);
        }
    }
}
