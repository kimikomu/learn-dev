// Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] 
// such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

// Notice that the solution set must not contain duplicate triplets.

// ------------------------------------------
// Hint #1: So, we essentially need to find three numbers x, y, and z such that they add up to the given value. 
// If we fix one of the numbers say x, we are left with the two-sum problem at hand!

// Hint #2: For the two-sum problem, if we fix one of the numbers, say x, we have to scan the entire array to find the next number y,
// which is value - x where value is the input parameter. Can we change our array somehow so that this search becomes faster?

// Hint #3: The second train of thought for two-sum is, without changing the array, can we use additional space somehow? 
// Like maybe a hash map to speed up the search?
// ------------------------------------------


using System;
using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {

        // 1. Sort the array to enable two-pointer approach
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();

        // 2. Iterate through each element in the array
        for (int i = 0; i < nums.Length - 2; i++) 
        {
            // Skip duplicates for the first number
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            // 3. Two-pointer approach
            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right) 
            {
                int sum = nums[i] + nums[left] + nums[right];

                if (sum == 0) 
                {
                    // Found a valid triplet
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });

                    // Skip duplicates for the second and third numbers
                    while (left < right && nums[left] == nums[left + 1])
                    {
                        left++;
                    }
                    while (left < right && nums[right] == nums[right - 1]) 
                    {
                        right--; 
                    }

                    // Move pointers inward after finding a valid triplet
                    left++;
                    right--;
                } 
                else if (sum < 0) 
                {
                    // If the sum is less than zero, move the left pointer to the right
                    left++;
                } 
                else 
                {
                    // If the sum is greater than zero, move the right pointer to the left
                    right--;
                }
            }
        }

        return result;
    }
}

