public class CustomStack<T>
{
    private CustomNode<T> _head;
    private int _count;

    public bool IsEmpty { get { return _count == 0; } }
    public int Count { get { return _count; } }

    public void AddElement(T obj)
    {
        CustomNode<T> node = new CustomNode<T>(obj);
        node.Next = _head;
        _head = node;
        _count += 1;
    }

    public T TakeElement()
    {
        CustomNode<T> tempNode = _head;
        _head = tempNode.Next;
        _count -= 1;
        return tempNode.Data;
    }

    public T GetHead()
    {
        return _head.Data;
    }
}