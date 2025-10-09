// You are given two arrays of integers (array1 and array2), each containing n elements, with n ranging from 1 to 50.
// Each element in both arrays can range from -1000 to 1000, inclusive.

// Your task is to write a C# method that identifies pairs of integers (a, b) wherein a belongs to array1 and b belongs to array2,
// and a is greater than b. The method should return all such pairs in the order in which a appears in array1.

// For instance, if array1 consists of {5, 1, 8, -2, 0} and array2 comprises {3, 2, 7, 10, -1},
// the output should be List<(int, int)> { (5, 3), (5, 2), (5, -1), (1, -1), (8, 3), (8, 2), (8, 7), (8, -1), (0, -1) }.

// Importantly, the order of elements in the output tuples should reflect the sequence in which a appears in array1.
// A pair cannot be included more than once. If no pair meets the condition, the method should return an empty list.

// Hint: Solving this task requires the use of nested loops. The outer loop should iterate through array1 and the inner loop through array2,
// checking the condition a > b during each iteration.




using System;
using System.Collections.Generic;

public class Solution
{
    // NESTED LOOPS
    public static List<(int, int)> FindPairs(int[] array1, int[] array2)
    {
        List<(int, int)> result = new List<(int, int)>();

        foreach (int num1 in array1)
        {
            foreach (int num2 in array2)
            {
                if (num1 > num2 && !result.Contains((num1, num2)))
                {
                    result.Add((num1, num2));
                }
            }
        }
        return result;
    }


    // USING HASHSET to AVOIT DUPLICATE ENTRIES - Not ideal if you want to keep the original order
    public static List<(int, int)> FindPairs(int[] array1, int[] array2)
    {
        HashSet<(int, int)> result = new HashSet<(int, int)>();

        foreach (int num1 in array1)
        {
            foreach (int num2 in array2)
            {
                if (num1 > num2)
                {
                    result.Add((num1, num2));
                }
            }
        }

        return new List<(int, int)>(result);
    }
}