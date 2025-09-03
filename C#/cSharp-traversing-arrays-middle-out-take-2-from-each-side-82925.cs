// You are provided with an array of n integers, where n ranges from 1 to 501 and is always an odd number. The elements of the array span values from 
// − 1,000,0000 to 1,000,000, inclusive. The goal is to return a new array constructed by traversing the initial array in a specific order, outlined as follows:

// Begin with the middle element of the array.
// For each subsequent pair of elements, alternate between taking two elements from the left and two elements from the right, relative to the middle.
// If fewer than two elements remain on either side, include all the remaining elements from that side.
// Continue this process until all elements of the array have been traversed.

// For example, for array = [1, 2, 3, 4, 5, 6, 7], your function should return [4, 2, 3, 5, 6, 1, 7]. And for array = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11],
// your function should return [6, 4, 5, 7, 8, 2, 3, 9, 10, 1, 11].

using System;
using System.Collections.Generic;

public class Solution
{

    // FIRST ATTEMPT
    public static List<int> UnusualTraversal(List<int> array)
    {
        int length = array.Count;
        if (length <= 1) { return array; }

        List<int> result = new List<int>();

        int mid = length / 2;
        int left = mid - 1;
        int right = mid + 1;

        // array is always odd, so add middle number no matter what
        result.Add(array[mid]);

        // while left and right are in bounds
        while (left >= 0 && right < length)
        {
            // break if we are out of bounds
            if (left <= 0 || right >= length - 1)
            {
                break;
            }

            // add 2 left spots and move 2 left spaces
            result.Add(array[left - 1]);
            result.Add(array[left]);
            left -= 2;

            // add 2 right spots and move 2 right spaces
            result.Add(array[right]);
            result.Add(array[right + 1]);
            right += 2;
        }

        // add leftover single numbers if there are any
        if (result.Count < length)
        {
            result.Add(array[0]);
            result.Add(array[length - 1]);
        }

        return result;
    }


    // Add double numbers and any single leftovers in one loop
    public static List<int> UnusualTraversal(List<int> array)
    {

        int length = array.Count;
        if (length <= 1) { return array; }

        List<int> result = new List<int>();

        int mid = length / 2;
        int left = mid - 1;
        int right = mid + 1;

        result.Add(array[mid]);

        // while there are numbers on either end of the array
        while (left >= 0 || right < length)
        {
            // left check
            if (left - 1 >= 0)      // if there are 2 numbers to take, take 2 and move left 2 spaces...
            {
                result.Add(array[left - 1]);
                result.Add(array[left]);
                left -= 2;
            }
            else                    // if not, take 1 and move left
            {
                result.Add(array[left]);
                left--;
            }

            // right check
            if (right + 1 < length) // if there are 2 numbers to take, take  and move right 2 spaces...
            {
                result.Add(array[right]);
                result.Add(array[right + 1]);
                right += 2;
            }
            else                    // if not take 1 and move right
            {
                result.Add(array[right]);
                right++;
            }
        }

        return result;
    }
}
