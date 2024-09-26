// You're playing Battleship on a grid of cells with R rows and C columns. There are 0 or more battleships on the grid,
// each occupying a single distinct cell. The cell in the ith row from the top and jth column from the left
// either contains a battleship (Gi,j = 1) or doesn't (Gi,j = 0).
// You're going to fire a single shot at a random cell in the grid. You'll choose this cell uniformly at random
// from the R ∗ C possible cells. You're interested in the probability that the cell hit by your shot contains a battleship.
// Your task is to implement the function getHitProbability(R, C, G) which returns this probability.


class Solution {
    public double getHitProbability(int R, int C, int[,] G)
    {
        int totalCells = R * C;
        int battleships = 0;

        // Count the number of battleships (i.e., cells with G[i, j] == 1)
        for (int i = 0; i < R; i++)
        {
            for (int j = 0; j < C; j++)
            {
                if (G[i,j] == 1) // G[i,j] is different than G[i][j]. Don't let it trip you up! Make sure to look at the paramaters!
                {
                    battleships++;
                }
            }
        }
        return (double)battleships/totalCells;
    }

    // Inputs and Testing
    public static void Main(string[] args)
    {
        Solution sol = new Solution(); // An object referance is required bc Solution.getHitProbability is not static.
        
        // Example grid with 2 battleships
        int[,] G = {
            { 0, 0, 1 },
            { 1, 0, 0 },
            { 0, 0, 0 }
        };
        int R = 3, C = 3;

        double probability = sol.getHitProbability(R, C, G);
        Console.WriteLine("Hit Probability: " + probability);
    }
}


// Time complexity = O(n * m) because we iterate through every cell in the grid.

// Space complexity = O(1) because we use a fixed amount of extra space (only a few variables).
// The grid is provided as input, so no additional storage is used proportional to the grid size.
