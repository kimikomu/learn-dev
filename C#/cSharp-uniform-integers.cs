// A positive integer is considered uniform if all of its digits are equal. For example 222 is uniform while 223 is not. Given two positive integers
// A and B, determine the number of uniform integers between A and B, inclusive. 

// Sample test case #1
// A = 75
// B = 300
// Expected Return Value = 5

// Sample test case #2
// A = 1
// B = 9
// Expected Return Value = 9

// Sample test case #3
// A = 999999999999
// B = 999999999999


using System;
using System.Collections.Generic;
using System.Text;

public class Solution {
    public int GetUniformIntegerCountInInterval(long A, long B) 
    {
        if (A == B)
        {
            return 1;
        }
        
        // Get number in first digit of A...
        string numStringA = A.ToString();
        StringBuilder sb = new StringBuilder(numStringA);
        string currentDigitString = sb[0].ToString();
        sb.Clear();
        
        // then turn it into a number.
        long currentNumAtCurrentDigit;
        long.TryParse(currentDigitString, out currentNumAtCurrentDigit);
        
        long currrentNum = A;
        int count = 0;

        // Collect a 1 for every digit in A
        foreach (char letter in numStringA)
            sb.Append("1");

        // loop through number places
        for (long placeCount = 1; placeCount <= B; placeCount *= 10)
        {
            // Console.WriteLine($"currrentNum: {currrentNum}, placeCount: {placeCount}");
            if (currrentNum > placeCount)
            {
                continue;
            }

            while (currrentNum <= B && currrentNum >= A)
            {
                string multiplByString = sb.ToString();
                long.TryParse(multiplByString, out long multiplBy);

                currrentNum = (currentNumAtCurrentDigit * multiplBy);
                currentNumAtCurrentDigit += 1;

                if (currentNumAtCurrentDigit >= 10)
                {
                    sb.Append("1");
                    currentNumAtCurrentDigit = 1;
                }

                if (currrentNum <= B)
                {
                    // Console.WriteLine($"currrentNum: {currrentNum}");
                    count++;
                }
            }
        }
        
        return count;
    }

    public static void Main()
    {
        var sol = new Solution();
        long A = 75;
        long B = 300;
        int count = sol.GetUniformIntegerCountInInterval(A, B);
        Console.WriteLine($"count: {count}");
    }
}