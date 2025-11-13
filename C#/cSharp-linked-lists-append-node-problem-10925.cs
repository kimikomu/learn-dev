class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}


class LinkedList
{
    private Node _head;

    public void Append(int data)
    {
        // create a node to add
        Node node = new Node(data);

        // if the linked-list does not have a head (is empty)...
        if (_head == null)
        {
            // the new node becomes the head
            _head = node;
        }
        else
        {
            // the last node represents the node we are currently on, which will eventually be the last node in the list
            Node last = _head;

            // while there is a node after this node..
            while (last.Next != null)
            {
                // it becomes the one we are on
                last = last.Next;
            }

            // when the last node does not have one next to it, our new node becomes last
            last.Next = node;
        }
    }
}
