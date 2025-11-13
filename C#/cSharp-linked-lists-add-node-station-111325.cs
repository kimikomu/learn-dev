class Node {
    public int Id;
    public Node Next;
    public string StationName;

    public Node(int id, string stationName) {
        Id = id;
        Next = null;
        StationName = stationName;
    }
}

class RailwayNetwork {
    private Node head;

    public void AddStation(int stationId, string stationName) {
        Node newStation = new Node(stationId, stationName);
        if (head == null) {
            head = newStation;
        } else {
            Node last = head;
            while (last.Next != null) {
                last = last.Next;
            }
            last.Next = newStation;
        }
    }
    
    public void ShowStations() {
        Node current = head;
        while (current.Next != null) {
            System.Console.Write(current.StationName + " ----> ");
            current = current.Next;
        }
        System.Console.WriteLine(current.StationName);
    }
}

class Solution {
    public static void Main(string[] args) {
        RailwayNetwork network = new RailwayNetwork();
        network.AddStation(101, "Hello");
        network.AddStation(202, "Goodbye");
        network.AddStation(303, "What's Up");
        network.ShowStations();
    }
}