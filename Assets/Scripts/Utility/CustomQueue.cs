public class CustomQueue<T>
{
    private CustomNode<T> _head;
    private CustomNode<T> _tail;
    private int _count;

    public bool IsEmpty { get { return _count == 0; } }
    public int Count { get { return _count; } }

    public void AddElement(T data)
    {
        CustomNode<T> node = new CustomNode<T>(data);
        CustomNode<T> tempNode = _tail;
        _tail = node;

        if (IsEmpty)
        {
            _head = _tail;
        }
        else
        {
            tempNode.Next = _tail;
        }

        _count += 1;
    }

    public T RemoveElement()
    {
        T output = _head.Data;
        _head = _head.Next;
        _count -= 1;
        return output;
    }

    public T TakeFirstElement()
    {
        return _head.Data;
    }

    public T TakeLastElement()
    {
        return _tail.Data;
    }

    public void Clear()
    {
        _head = null;
        _tail = null;
        _count = 0;
    }

    public bool Contain(T data)
    {
        CustomNode<T> current = _head;

        while (current != null)
        {
            if (current.Data.Equals(data))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }
}