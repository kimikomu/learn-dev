// You are given an array of n integers, where n can range from 1 to 500, inclusive. Your task is to create a new array in which each element is a tuple,
// determined by pairing elements from the middle to both ends of the original array.

// If the original array has an odd length, pair the middle element with 0. If the original array has an even length, start pairing from the two middle elements.
// Continue the pairing by alternating elements from the left and the right until all elements have been paired.

// After creating the paired elements, return the new array of tuples. Ultimately, your result should be an array of tuples, each of size two,
// where each element within a tuple, as well as within the array, can range from -1000 to 1000, inclusive.

// Note: You are not allowed to use built-in methods that reverse the order of elements, such as the Reverse() method.

// For example, if the input is numbers = [1, 2, 3, 4, 5], the output should be [(3, 0), (2, 4), (1, 5)].
// Similarly, if the input is numbers = [1, 2, 3, 4], the output should be [(2, 3), (1, 4)].


using System;
using System.Collections.Generic;

public class Solution
{
    // input: List of numbers btw 1 - 500 inclusive. Each number in the list can range from -1000 to 1000 inclusive.
    // todo: Moving from the center out, pair the symetrically located numbers into a tuple and add them to a list. If the
    //       original list is odd, pair the center element with 0.
    // output: Return a list of the tuples.
    public static List<(int, int)> Solve(List<int> numbers)
    {
        List<(int, int)> tuples = new List<(int, int)>();

        if (numbers.Count == 1)
        {
            tuples.Add((numbers[0], 0));
            return tuples;
        }

        // get the middle number
        int mid = numbers.Count / 2;

        // get the left and right numbers
        int left = mid - 1;
        int right = mid;

        // if numbers is odd, move right over one, add mid number and 0 as a tuple to list
        if (numbers.Count % 2 == 1)
        {
            tuples.Add((numbers[mid], 0));
            right = mid + 1;
        }

        // loop moving center out
        while (left >= 0 && right < numbers.Count)
        {
            tuples.Add((numbers[left], numbers[right]));
            left--;
            right++;
        }

        return tuples;
    }
}
