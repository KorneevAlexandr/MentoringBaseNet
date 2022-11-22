using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node _firstNode;
        private Node _lastNode;
        private int _length;

        public int Length => _length;

        public void Add(T e)
        {
            if (_firstNode == null)
            {
                _firstNode = new Node(e, null, null);
                _lastNode = _firstNode;
            }
            else
            {
                _lastNode.Next = new Node(e, _lastNode, null);
                _lastNode = _lastNode.Next;
            }

            _length++;
        }

        public void AddAt(int index, T e)
        {
            if (index == _length)
            {
                Add(e);
            }
            else
            {
                var currentNode = NodeAt(index);
                var previousNode = currentNode.Previous;
                var newNode = new Node(e, previousNode, currentNode);
                currentNode.Previous = newNode;
                _length++;
                
                if (previousNode != null)
                {
                    previousNode.Next = newNode;
                }
                else
                {
                    _firstNode = newNode;
                }
            }
        }

        public T ElementAt(int index)
        {
            return NodeAt(index).Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(_firstNode);
        }

        public void Remove(T item)
        {
            var node = _firstNode;

            for (int i = 0; i < _length; i++)
            {
                if (node.Value.Equals(item))
                {
                    RemoveNode(node);
                    _length--;

                    break;
                }

                node = node.Next;
            }
        }

        public T RemoveAt(int index)
        {
            var currentNode = NodeAt(index);
            RemoveNode(currentNode);
            _length--;

            return currentNode.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(_firstNode);
        }

        private Node NodeAt(int index)
        {
            if (index < 0 || index >= _length)
            {
                throw new IndexOutOfRangeException("Specified index was out of range.");
            }

            Node resultNode = _firstNode;

            for (int i = 0; i < index; i++)
            {
                resultNode = resultNode.Next;
            }

            return resultNode;
        }

        private void RemoveNode(Node node)
        {
            var previousNode = node.Previous;
            var nextNode = node.Next;

            if (previousNode == null)
            {
                _firstNode = nextNode;
            }
            else
            {
                previousNode.Next = nextNode;
            }

            if (nextNode == null)
            {
                _lastNode = previousNode;
            }
            else
            {
                _lastNode.Previous = previousNode;
            }
        }

        private struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private Node _firstNode;
            private Node _current;
            private bool _isFirstStep;

            public Enumerator(Node firstNode)
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

        private class Node
        {
            public Node(T value, Node previous, Node next)
            {
                Value = value;
                Previous = previous;
                Next = next;
            }

            public T Value { get; set; }

            public Node Previous { get; set; }

            public Node Next { get; set; }
        }
    }
}
