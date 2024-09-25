// Use this for smaller arrays, NOT huge datasets.

using System;

class Solution
{
    public static double FindMedian(int[] nums)
    {
        // Step 1: Sort the array
        Array.Sort(nums);

        int length = nums.Length;

        // Step 2: Find the median
        if (length % 2 == 1)
        {
            // Odd number of elements, return the middle element
            return nums[length / 2];
        }
        else
        {
            // Even number of elements, return the average of the two middle elements
            return (nums[length / 2 - 1] + nums[length / 2]) / 2.0;
        }
    }

    // Inputs and testing
    static void Main()
    {
        int[] nums = { 7, 3, 1, 4, 6, 5, 2 };
        double median = FindMedian(nums);
        Console.WriteLine("Median: " + median);
    }
}
