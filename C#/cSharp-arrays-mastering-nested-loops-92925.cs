// You are provided with two arrays of unique integers, with the lengths of these arrays ranging from 1 to 100, inclusive.
// Your task is to identify elements that appear in both arrays and return them in a new list, maintaining the order from the first provided array.

// Each element in the arrays ranges from -100 to 100, inclusive.

// Implement a method CommonElements(int[] array1, int[] array2) where array1 and array2 represent the two input arrays.
// The method should return a list of integers that includes the common elements found in both array1 and array2, while preserving the order of elements as they appear in array1.

// For example, if array1 = new int[] {7, 2, 3, 9, 1} and array2 = new int[] {2, 3, 7, 6}, the output should be new List<int> {7, 2, 3}.


using System;
using System.Collections.Generic;

// input: 2 arrays of unique ints - length 1 to 100.
// todo: find ints in both arrays and create new list, maintaining order from array 1
// output: new list of common ints
public class Solution
{
    // FIRST ATTEMPT - Nested loops: O(N^2) - Quadratic time
    public static List<int> CommonElements(int[] array1, int[] array2)
    {
        List<int> result = new List<int>();

        // Loop through array 1
        foreach (int num in array1)
        {
            // Loop through  array 2
            foreach (int num2 in array2)
            {
                // if num in array 1 matches num in array t
                if (num == num2)
                {
                    result.Add(num);
                }
            }
        }

        return result;
    }
    
    // Using HashSet<int> - O(m + n) - Linear time
    public static List<int> CommonElements(int[] array1, int[] array2)
    {
        List<int> result = new List<int>();
        HashSet<int> dictionary = new HashSet<int>(array2);

        // Loop through array 1 and 2
        foreach (int num in array1)
        {
            if (dictionary.Contains(num))
            {
                result.Add(num);
            }
        }

        return result;
    }


}