// Your task is to write a C# function that takes in a string and identifies all the consecutive groups of identical characters within it,
// with the analysis starting from the end of the string rather than from its beginning. A group is defined as a segment of the text where the same character is repeated consecutively.

// Your function should return a list of tuples. Each tuple will consist of the repeating character and the number of its repetitions.
// For instance, if the input string is "aaabbcccdde", the function should output: [('e', 1), ('d', 2), ('c', 3), ('b', 2), ('a', 3)].

// Note that the input string cannot be empty; in other words, it must contain at least one character, and its length must not exceed 500 characters.
// The return should also be in reverse order, starting from the group of repeated characters at the end of the string and moving backward.

// Put your knowledge and skills into action to solve this reverse pattern identification puzzle!



using System;
using System.Collections.Generic;

public class Solution
{
    // input: string - character pattern btw 1 and 500 chars inclusive
    // todo: move backwards through the string and count each char's consecutive repetitions
    // output: list of tuples containing each char and its repetition count. tuples should be in reverse order of original string
    
    // question: should chars that are not letters or numbers be included in the list of tuples? yes. includle all charachters
    //           since that isn't specified.
    public static List<(char, int)> GetConsecutiveGroupsReverse(string s)
    {
        int length = s.Length - 1;
        if (length < 0 || length > 500)
        {
            //throw new Exception("String length does not meet requirements. Length should include at least 1 char and no more than 500.");
            return new List<(char, int)>();
        }
        
        // make a list for tuples
        List<(char, int)> result = new List<(char, int)>();
        int count = 1;
        
        // loop through s backwards
        for (int i = length; i > 0; i--)
        {
            // if the current char and the previous one are different
            if (s[i] != s[i - 1])
            {
                // add the current char and its repetion count to the list as a tuple
                result.Add((s[i], count));
                count = 1;
            }
            else
            {  
                // else continue count
                count++;
            }
        }
        
        // add the fisrt character
        result.Add((s[0], count));
        
        // return list of tuples
        return result;
    }
}
