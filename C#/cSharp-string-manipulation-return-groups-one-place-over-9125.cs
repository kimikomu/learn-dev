// You are given a string of n characters, with n varying from 1 to 1000, inclusive. Your task is to write a C# function that takes this string as input,
// applies the following operations, and finally returns the resulting string.

// Split the given string into individual words, using a space as the separator.
// Convert each word into a list of its constituent characters, and shift each list once to the right (with the last element moving to the first position).
// After the rotations, reassemble each word from its list of characters.
// Join all the words into a single string, separating adjacent words with a single space.
// Return this final string as the function's output.

// The constraints for the problem are as follows:
// The input string will neither start nor end with a space, nor will it have multiple consecutive spaces.
// Each word will contain only alphabets and digits, and its length will range from 1 to 10.
// Your program should output a single string with the words rotated by their lengths while preserving their original order.

// As an illustration, consider the input string "abc 123 def". Applying the stated operations results in the output "cab 312 fde".

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public class Solution
{
    // input: string of letters and numbers seperated by space into groups btw 1 and 1000 inclusive. each group will be < 10 chars
    // todo: for each group, shift the chars once to the right. the last char should wrap around to the first position
    // output: string - groups of chars in the same order as input seperated by a space, but chars shifted one place over within their group


    // USING LOOP AND SUBSTRING
    public static string Transform(string inputStr)
    {
        string[] groups = inputStr.Split();
        List<string> rotatedArray = new List<string>();
        
        foreach (string group in groups)
        {
            string rotated = group.Substring(group.Length - 1, 1) + group.Substring(0, group.Length - 1);
            rotatedArray.Add(rotated);
        }
    
        string result = String.Join(" ", rotatedArray.ToArray());
        
        return result;
    }


    // USING LINQ
    public static string Transform(string inputStr)
    {
        string[] groups = inputStr.Split();

        string[] shiftedGroups = groups.Select(group => new String(group[group.Length - 1] + group.Substring(0, group.Length - 1))).ToArray();

        string result = String.Join(" ", shiftedGroups);

        return result;
    }


    // USING C#8 and later sytax
    // NOTE: arr[^1] and arr[..^1] works for all array types.
    //       Also can be used for all indexes: 
    //          arr[^2]: the 2nd to last element 
    //          arr[..^2]: all elements up to, but not including the 2nd to last element
    public static string Transform(string inputStr)
    {
        string[] groups = inputStr.Split();

        // group[^1]: the last element 
        // group[..^1]: from the start up to, but not including, the last element
        string[] shiftedGroups = groups.Select(group => group[^1] + group[..^1]).ToArray();

        string result = String.Join(" ", shiftedGroups);

        return result;
    }


    // USING SPAN
    // NOTE: FOR LEARNING ONLY! Don't use spans in this way for this kind of problem.
    //                    To be used when you want to avoid allocations and work with slices of data in-place (like with arrays or buffers).
    // Span<T> - A window for changing arrays and strings
    //      Does not own the data, but points to a region of memory
    //      Mutable if the underlying data is mutable
    //      FAST - Stack-only. Does not copy data. Does not cause garbage collection.
    //      strings - Must use ReadOnlySpan<char>. To save string changes, must create a new string using ToString().
    public static string Transform(string inputStr)
    {
        string[] groups = inputStr.Split();

        string[] spanString = groups.Select(group => new String(group.AsSpan(group.Length - 1, 1).ToString() + group.AsSpan(0, group.Length - 1).ToString())).ToArray();

        string result = String.Join(" ", spanString);

        return result;
    }
}
