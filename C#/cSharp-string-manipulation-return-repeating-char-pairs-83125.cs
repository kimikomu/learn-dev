// In this task, you are required to write a C# function that takes a string as input and identifies
// all consecutive groups of identical pairs of characters within it. A group can be defined as a segment of the text
// where the same pair of characters is repeated consecutively.

// Your function should return a string representing all the repeating character pairs and the number of their repetitions.
// For instance, if the input string is "aaabbabbababaca", your function should output: "aa1ab1ba1bb1ab2ac1a1".
// Note that if the length of the input string is odd, the last character is not paired with any other
// and is just added to the resulting string with repetition count 1.

// Unlike in the lesson, the input strings for this task are guaranteed to consist only of lowercase alphabetic characters.
// The length of the string will not exceed 500 characters.

// Can you develop such a program? Get set, go!

using System;
using System.Text;

public class Solution
{
    // input: string - char pattern of lowercase letters that will not exceed 500 chars
    // todo: count consecutive repetitions of each pair of chars. leftover char for an odd number of string length will always be that char and 1
    // output: new string that represents all repeating char pairs and their repetition counts

    // First Attempt
    public static string GetConsecutivePairs(string s)
    {
        // check if s is outside bounds
        int length = s.Length - 1;

        // create StringBuilder
        var sb = new StringBuilder();

        // keep track of repetition counts of pairs
        int count = 1;

        // loop through s
        for (int i = 0; i + 2 < length; i += 2)
        {
            string pair = s[i].ToString() + s[i + 1].ToString();
            string nextPair = s[i + 2].ToString() + s[i + 3].ToString();

            // if the next pair does not match the current pair
            if (pair != nextPair)
            {
                // add the pair and the count to the string builder
                sb.Append(pair + count);
                count = 1;
            }
            else
            {
                // else keep on counting
                count++;
            }
        }

        // if s length is odd
        if (s.Length % 2 == 1)
        {

            sb.Append(s[length - 2].ToString() + s[length - 1].ToString() + count);

            // add the last char and 1 to the string builder
            sb.Append(s[length].ToString() + 1);
        }
        else
        {
            sb.Append(s[length - 1].ToString() + s[length].ToString() + count);
        }

        return sb.ToString();
    }



    // Using Substring() for better clarity
    public static string GetConsecutivePairs(string s)
    {
        int pairCount = 1;
        int length = s.Length;
        int lengthMinusPair = length - 2;

        var sb = new StringBuilder();

        for (int i = 0; i < lengthMinusPair - 1; i += 2)
        {
            string pair = s.Substring(i, 2);
            string nextPair = s.Substring(i + 2, 2);

            // if the next pair does not match the current pair
            if (pair != nextPair)
            {
                // add the pair and the count to the string builder
                sb.Append(pair + pairCount);

                // reset count
                pairCount = 1;
            }
            else
            {
                pairCount++;
            }
        }

        // if s length is even, add the last pair and its count
        if (length % 2 == 0)
        {
            string lastPair = s.Substring(lengthMinusPair, 2);
            sb.Append(lastPair + pairCount);
        }
        else // if s length is odd
        {
            string lastPair = s.Substring(lengthMinusPair - 1, 2);
            string leftoverChar = s.Substring(length - 1, 1);

            // add last pair and count, then leftover char and 1
            sb.Append(lastPair + pairCount + leftoverChar + 1);
        }

        return sb.ToString();
    }
}