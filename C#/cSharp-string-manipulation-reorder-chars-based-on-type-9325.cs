// You are provided with a string of alphanumeric characters where each number, regardless of the number of digits,
// is always followed by at least one alphabetic character before the next number appears. Your task is to return a transformed version
// of the string wherein the first alphabetic character following each number is moved to a new position within the string and characters in between are removed.
// Specifically, for each number in the original string, identify the next letter that follows it, and then reposition that character to directly precede the number.
// All spaces and punctuation marks between the number and the letter are removed.

// The length of the string s ranges from 3 to 1,000,000 (inclusive), and the string contains at least one number.
// The numbers in the string are all integers and are non-negative.

// Here is an example for better understanding:
// Given the string:
// "I have 2 apples and 5! oranges and 3 grapefruits."
// The function should return:
// "I have a2pples and o5ranges and g3rapefruits."

// In this instance, the character 'a' following the number 2 is moved to come before the 2, the 'o' succeeding the 5 is placed before the 5,
// and the 'g' subsequent to the 3 is repositioned to precede the 3. Punctuation marks and spaces in between are removed.

// Please note that the operation should maintain the sequential order of the numbers and the rest of the text.
// Considering this, the task is not solely about dividing a string into substrings but also about modifying them.
// This will test your expertise in C# string operations and type conversions.



using System;
using System.Text;

// input: string of non-negative ints and letters (length from 3 to 1,000,000) where every int is followed by at least one letter.
// todo: move the number chars to the right of the first following letter char. Remove all spaces and punctuation between the num and letter
// output: new string in the same order of original, except for the numbers and removal of the relevent spaces and puntuation 


// FIRST ATTEMPT USING LOOP
public class StringTransformer
{
    public static string TransformString(string inputString)
    {
        var numString = new StringBuilder();
        var result = new StringBuilder();

        // loop through string
        foreach (char ch in inputString)
        {
            if (char.IsDigit(ch))       // the char is a num
            {
                // save the char in a string
                numString.Append(ch);
            }
            else if (char.IsLetter(ch) && numString.Length > 0) // the char is a letter (not a space or punctuation) && a num has been saved
            {
                // add the letter to the result string
                result.Append(ch);

                // add the numString to the result string
                result.Append(numString);

                // clear the numString for a new set of numbers
                numString.Clear();
            }
            else if (numString.Length <= 0)     // if no number has been saved
            {
                // add the char to the result string
                result.Append(ch);
            }
        }

        return result.ToString();
    }
}
