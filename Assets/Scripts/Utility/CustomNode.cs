public class CustomNode<T>
{
    public T Data;
    public CustomNode<T> Next;

    public CustomNode(T data)
    {
        Data = data;
    }
}