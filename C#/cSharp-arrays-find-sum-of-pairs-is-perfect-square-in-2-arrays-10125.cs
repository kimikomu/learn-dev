using System;
using System.Collections.Generic;

// input: 2 arrays of ints. sizes do not need to match eachother. both btw -100 and 100 inclusive.
// todo: find pairs of ints where the 1st int is from the 1st array, and the 2nd is from the 2nd array. The sum of the pair is a perfect square.
// output: List of these pairs in the order that coresponds to the order of both arrays. OR an empty list if no pairs exist.
public class Solution
{
    public static List<(int, int)> FindPairs(int[] arr1, int[] arr2)
    {
        List<(int, int)> result = new List<(int, int)>();

        // loop through arr1
        foreach (int num1 in arr1)
        {
            // loop through arr2
            foreach (int num2 in arr2)
            {
                // get square root of sum
                double sqr = Math.Sqrt(num1 + num2);

                // Math.Floor(sqr) will turn sqr into an int, so if the int version matches the double version (possible decimal),
                // we know that sqr is a whole number and is therefore a perfect square
                if (Math.Floor(sqr) == sqr)
                {
                    // add to list
                    result.Add((num1, num2));
                }
            }
        }

        return result;
    }
}
