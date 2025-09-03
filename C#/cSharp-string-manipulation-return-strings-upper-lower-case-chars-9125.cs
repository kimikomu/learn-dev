// You are given a string filled with words. Your task is to write a C# function that takes this string as input.
// Your function should then capitalize the first letter of each word while making the rest of the letters lowercase.
// Finally, it should recombine the words into a new string where every word starts with a capital letter.

// Here's what to keep in mind:

// The input string will contain between 1 and 100 words.
// Each word is a sequence of characters separated by white space.
// Words consist of characters ranging from a to z, A to Z, 0 to 9, or even an underscore _.
// The provided string will not start or end with a space, and it will not contain double spaces.
// After capitalizing the first character of each word and converting the rest to lowercase, the program should return a single string in which the words maintain their original order.
// If the first character of a word is not a letter (like a number or an underscore), keep it as is.
// Ignore cases where punctuation marks are attached to words (such as "Hello," or "world!"). Words and punctuation should retain their original places in your final output. You are not required to separate punctuation marks from the words in your solution.

// Example:
// For the input string "SoME rAndoM _TeXT", the output should be "Some Random _text".


using System;
using System.Collections.Generic;
using System.Text;

public class Solution
{
    // input: string of words btw 1 - 100. words can contain chars other than letters
    // todo: capitalize the first char of each word if it is a letter, change the remaining letters lowercase. leave non-letter chars as is
    // output: string of words with same words and punctuation, but the first letter of the word is capitalized (if a letter), and the rest are lowercase

    // FIRST ATTEMPT USING LOOPS
    public static string CapitalizeWords(string inputStr)
    {
        // create array from input
        string[] words = inputStr.Split();
        List<string> caseWords = new List<string>();

        // for each word
        foreach (string word in words)
        {
            var sb = new StringBuilder();

            char ch = word[0];

            if (Char.IsLetter(word[0]))
            {
                ch = Char.ToUpper(word[0]);
            }

            sb.Append(ch);

            for (int i = 1; i < word.Length; i++)
            {
                char chi = word[i];

                if (Char.IsLetter(word[i]))
                {
                    chi = Char.ToLower(word[i]);
                }

                sb.Append(chi);
            }

            caseWords.Add(sb.ToString());
        }

        return String.Join(" ", caseWords);
    }


    // USING LINQ - a little hard to read
    public static string CapitalizeWords(string inputStr)
    {   
        string[] caseWords = inputStr.Split()                   // Split the input string.
            .Select(word =>                                     // For each word...
                new String(Char.ToUpper(word[0]) +              // make a new string with the first letter capitalized
                word.Substring(1, word.Length - 1).ToLower()))  // and the rest of the letters lowercase.
            .ToArray();                                         // Save these new strings in an array
            
        return String.Join(" ", caseWords);
    }
}
