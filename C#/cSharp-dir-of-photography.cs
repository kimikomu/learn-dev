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


// Iterate over all the cells

// For each cell check if it is an A

// If an A is found
    // Check the left of the cell for a P and that the distance is within the X an Y values
    // Check the right of the cell for a B and that the distance is within the X an Y values

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
        int totalSets = 0;
        char photo = 'P';
        char backdrop = 'B';
        
        // Iterate over all the cells
        for (int i = 0; i < N; i++)
        {
            if (C[i] == 'A')
            {
                int leftToRightSets = FindValidSets(N, C, X, Y, i, photo, backdrop);
                int rightToLeftSets = FindValidSets(N, C, X, Y, i, backdrop, photo);

                totalSets += leftToRightSets + rightToLeftSets;
            }
        }
        
        return totalSets;
    }

    public static int FindValidSets(int N, string C, int X, int Y, int i, char S, char T)
    {
        int count = 0;
        
        // Check on the left of the actor
        for (int j = i - X; j >= Math.Max(0, i - Y); j--)
        {
            if (C[j] == S)
            {
                // Check right of the actor
                for (int k = i + X; k <= Math.Min(N - 1, i + Y); k++)
                {
                    if (C[k] == T)
                    {
                        count++; // Found a valid artistic photograph
                    }
                }
            }
        }

        return count;   
    }
}


// Time complexity is O(N * Y * Y) - yikes!
