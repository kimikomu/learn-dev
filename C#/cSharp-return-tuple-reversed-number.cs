using System;
using System.Collections.Generic;

// You are provided with a list of n integers, where n ranges from 2 to 200, inclusive. The task is to return a list of tuples, each containing a pair of an integer and its reverse counterpart.
// In this context, the reverse counterpart of a number is the number with its digits reversed. For example, the reverse counterpart of 123 is 321.
// You must iterate through the list to find the reverse counterpart for each integer. If this reversed number exists in the list, create a tuple with the original number and its reverse counterpart. If not, skip it.
// Your output should be a list of tuples with the original numbers and their reverse counterparts. The integers in the given list will range from 10 to 9999, inclusive, and each integer in the list is unique.

// Note: The reverse counterpart of a single digit number is the same number. For numbers that result in leading zeros when reversed (e.g., 100 becomes 001, which is 1), 
// consider only the integer value (i.e., 1). It's guaranteed that the original list will not contain integers with leading zeros.
// For example, for numbers = [12, 21, 34, 43, 56, 65], the output should be Solution(numbers) = [(12, 21), (21, 12), (34, 43), (43, 34), (56, 65), (65, 56)].

public class Solution
{
    // Solve with Math
    public static List<(int, int)> Solve(List<int> numbers)
    {
        List<(int, int)> tuple = new List<(int, int)>();
        int n = numbers.Count;

        for (int i = 0; i < n; i++)
        {
            int digit = 0;              // place holder for each digit of the number
            int reversed = 0;           // place holder to build the reversed number
            int newNum = numbers[i];    // copy the number to remove the last digit

            // itterate over each digit in the number
            while (newNum > 0)
            {
                // remove last digit of the number
                digit = newNum % 10;

                // move one place to the left and add the last digit of the original number to build the reversed number
                reversed = reversed * 10 + digit;
            }
            if (numbers.Contains(reversed))
            {
                tuple.Add((numbers[i], reversed));
            }
        }
        return tuple;
    }

    // Solve with strings
    
}