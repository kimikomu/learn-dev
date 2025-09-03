// Imagine you are given a string containing a series of words separated by a hyphen ("-"). Each word in the string can either be
// a lowercase letter from 'a' to 'z' or a digit representing a number between 1 and 26. Your task is to parse this string
// and swap the type of each word: convert numbers into their corresponding English alphabet letters and letters into their numerical equivalents.
// This means '1' should be converted to 'a', and 'a' to '1'.

// The goal is to return a new string with the converted words, rejoined with hyphens, preserving the original order of the words from the input string.
// The input string will have a length ranging from 1 to 1000, ensuring it will never be empty and will always contain at least one valid lowercase letter or numerical word.
// Your transformation should be limited to numbers from 1 to 26 converting into their corresponding letters from 'a' to 'z', and vice versa.

// Example
// For the input string "1-a-3-c-5", the output should be "a-1-c-3-e".

// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
// input: string of words seperated by a hyphen. each word will be either a number from 1 - 26, or a lowercase letter.
// todo: change each word to its coresponding place in the alphabet. Ex: 1 becomes 'a'. 'a' becomes 1.
// output: string of words seperated be a hyphen in the same order of the original input string, but with the letters turned to their alphabet numbers and the numbers turned to 
//          their ASCii letters
// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ 

using System;
using System.Linq;
using System.Collections.Generic;

// Finding the coresponding letter or number in ASCii:
//  'a' is index 0 in the alphabet, but 97 in ASCii

//  If our char is a number (1 - 26), we need to add 97 to find the correct character in ASCii.
//      Then subtract 1 to make up for the starting index (1 + 97 = 98, but 98 is 'b' in ASCii, so subtract 1 to make it 'a')

//  If our char is a letter ('a' - 'z'), we need to remove the ASCii number position to find the correct number. So we subtract 97 to get a starting index of 0.
//      Then add 1 to make up for the starting index difference. ('a' - 97 == 0, but 'a' needs to be 1, so add a 1 to get the correct starting number)

public class Solution
{
    // FIRST PASS USING LOOP
    public static string ConvertString(string s)
    {
        char alphabetIndex0 = 'a';
        string[] words = s.Split("-");
        List<string> result = new List<string>();

        foreach (string word in words)
        {
            if (char.IsNumber(word, 0))
            {
                // convert num to letter
                int numWord = int.Parse(word);                          // string to int
                char numLetter = (char)(alphabetIndex0 + numWord - 1);   // int to char

                result.Add(numLetter.ToString());                       // char to string
            }

            if (char.IsLetter(word, 0))
            {
                // convert letter to num
                char charWord = (char)word[0];                          // string to char
                int charNum = charWord - alphabetIndex0 + 1;             // char to int

                result.Add(charNum.ToString());                         // int to string
            }
        }

        return string.Join("-", result);
    }


    // LOOP - MORE COMPACT
    public static string ConvertString(string s)
    {
        string[] strings = s.Split("-");
        List<string> result = new List<string>();

        foreach (string word in strings)
        {
            string convertedWord = char.IsNumber(word, 0) ?         // Is the first char in the word a number?
                ((char)('a' + int.Parse(word) - 1)).ToString() :    // If yes, int to letter to string
                (word[0] - 'a' + 1).ToString();                     // If no, letter to number to string

            result.Add(convertedWord);
        }

        return string.Join("-", result);
    }


    // USING LINQ
    public static string ConvertString(string s)
    {
        string[] result = s.Split("-")
            .Select(word => char.IsNumber(word, 0) ?
                ((char)(int.Parse(word) + 'a' - 1)).ToString() : // string to int to char to string
                (word[0] - 'a' + 1).ToString())                 // char to int to string
            .ToArray();

        return string.Join("-", result);
    }
}
