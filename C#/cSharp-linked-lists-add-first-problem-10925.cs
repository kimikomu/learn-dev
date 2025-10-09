// The railway network is expanding, and you're at the helm! Your task is to direct the code that places a new station at the beginning of the line.
// Visualize nodes as stations and links as tracks as you dive into the RailwayNetwork's "AddStation" method.
// Update it so the latest station becomes the new starting point. Once you're done, run the program to watch your train's journey unfold.

// Basic Node Class
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

// Represents the Linked-List
class RailwayNetwork
{
    private Node _head;

    // Add First
    public void AddStation(int stationData)
    {
        // create a node to add
        Node node = new Node(stationData);

        // if the linked-list already has a head...
        if (_head != null)
        {
            // the new node's Next node becomes the head
            node.Next = _head;
        }

        // the new node becomes the head
        _head = node;
    }

    public void Show()
    {
        Node current = _head;
        while (current.Next != null)
        {
            Console.Write(current.Data + "-");
            current = current.Next;
        }
        Console.Write(current.Data);
    }
}

class Solution
{
    static void Main(string[] args)
    {
        RailwayNetwork network = new RailwayNetwork();
        // Adding stations with their station IDs
        network.AddStation(101);
        network.AddStation(202);
        network.AddStation(303);
        network.Show();
    }
}