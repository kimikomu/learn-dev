// You are provided with an array of n integers, where n can range from 1 to 200, inclusive. Your task is to create a new array
// that takes pairs of 'opposite' elements from the original array at each iteration, starting from the center and moving towards both ends,
// to calculate the resulting multiplication of each pair.

// By 'opposite' elements, we mean pairs of elements symmetrically located relative to the array's center.
// If the array's length is odd, the center element doesn't have an opposite and should be included in the result array as is.

// Each element in the array can range from -100 to 100, inclusive.

// Note: You are not allowed to use built-in methods that reverse the order of elements, such as the Reverse() method.

// For example, if the input array is [1, 2, 3, 4, 5], the returned array should be [3, 8, 5].
// This is because the center element 3 remains as it is, the multiplication of 2 and 4 is 8, and the multiplication of 1 and 5 is 5.


using System;
using System.Collections.Generic;

public class Solution
{
    // input: Array of numbers with a length btw 1 - 200 inclusive. Each element in the array can be btw -100 to 100 inclusive.
    // to do: Moving from the center of the array twards both ends, multiply the pairs of numbers symetrically located to the array's center and add the product to a list.
    //        If the array is odd, add the center number to the array as is, before moving to the left and right of the center.
    // output: A list with the products of the opposite numbers of the original array.

    public static List<int> Solve(int[] numbers)
    {
        if (numbers.Length <= 1)
        {
            return new List<int>(numbers);
        }

        List<int> products = new List<int>();
        int length = numbers.Length;
        int mid = length / 2;
        int left = mid - 1;     // the left most center number
        int right = mid;        // the right most center number (changes if the length of numbers is odd)

        // if the length of the numbers array is odd...
        if (length % 2 == 1)
        {
            products.Add(numbers[mid]); // add middle number to list
            right = mid + 1;            // move the right pointer to the right of the middle number
        }

        while (left >= 0 && right < length)
        {
            int product = numbers[left] * numbers[right];
            products.Add(product);

            // move pointers one to the left and right
            left--;
            right++;
        }

        return products;
    }
}