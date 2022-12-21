namespace Tasks
{
    public class LinkedNode<T>
    {
        public LinkedNode(T value, LinkedNode<T> previous, LinkedNode<T> next)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }

        public T Value { get; set; }

        public LinkedNode<T> Previous { get; set; }

        public LinkedNode<T> Next { get; set; }
    }
}
