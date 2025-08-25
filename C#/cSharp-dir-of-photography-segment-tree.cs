// A photography set consists of N cells in a row, numbered from 1 to N in order, and can be represented by a string C of length N. Each cell i is one of the following types
// (indicated by Ci, the ith character of C).
// if Ci = "P", it is allowed to contain a photographer.
// if Ci = "A", it is allowed to contain an actor.
// if Ci = "B", it is allowed to contain a backdrop.
// if Ci = ".", it must be left empty.
// A photograph consists of a photographer, an actor, and a backdrop, such that each of them is placed in a valid cell, and such that the actor is between the photographer 
// and the backdrop. Such a photograph is considered artistic if the distance between the photographer and the actor is between X and Y cells (inclusive) and the distance between
// the actor and the backdrop is also between X and Y cells (inclusive).The distance between cells i and j is i - j (the absolute value of the difference between their indices).

// Determine the number of different artistic photographs which could potentially be taken at the set. Two photographs are considered different if they involve a different
// photographer cell, actor cell, and/or backdrop cell.



// Count valid PAB sets

using System;

class Program
{
    static void Main()
    {
        string C = "PBAAPB"; // Example input
        int X = 1;
        int Y = 3;

        int result = CountArtisticPhotographs(C, X, Y);
        Console.WriteLine($"Number of artistic photographs: {result}");
    }

    static int CountArtisticPhotographs(string C, int X, int Y)
    {
        int N = C.Length;

        CreateTree():
        

        

        return 0;
    }

    public void CreateTree()
    {
        
    }
}

public class SegmentTree
{
    private int[] tree;
    private int size;

    // Initialize the tree with a given size 
    public SegmentTree(int size)
    {
        size = size;
        tree = new int[2 * size];
    }

    // Query sum in range [left, right]
    public void Query(int left, int right)
    {
        int sum = 0;
        left += size;
        right += size;

        while (left <= right)
        {
            if (left % 2 == 1)
            {
                sum += tree[left++];
                
            }
        }
    }
}

