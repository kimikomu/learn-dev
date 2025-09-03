// You are to implement the Run-Length Encoding (RLE) on an alphanumeric input string in C#. Run-length encoding is a simple form of data compression
// where sequences of data entities that are the same are stored as a single data entity along with its count. Each count must immediately follow the character it is associated with.

// The function to implement is EncodeRle, which takes a string as an input argument and returns a new string that represents the input's run-length encoding.

// The function should operate only on alphanumeric characters (numbers 0-9 and uppercase and lowercase letters A-Z, a-z). For any other types of characters in the string,
// simply ignore them and do not include them in the final encoded output.

// For instance, if the input string is "aaabbcccdde", the output should be "a3b2c3d2e1". If the input string includes non-alphanumeric characters,
// such as "aaa@@bb!!c#d**e", the output should be "a3b2c1d1e1".

// The input string can have up to 500 characters.



// Kimiko NOTE: of the 2 approaches below, when using large strings of data, it is best to use a StringBuilder
// Also, checking the last character in a string after the loop instead of withing the loop, would avoid an extra check for it every loop itteration

using System;

public class Solution
{
    // input: string of up to 500 characters
    // todo: count how many times each charater repeats sequentially 
    // output: new string of each character followed by the number of times it repeats sequentially. only letters and numbera are allowed

    // question: do uppercase and lowercase versions of a letter count as the same character? answer: they are to be treated as different characters
    public static string EncodeRle(string s)
    {
        // trackers for current character and repeating counts
        char? currentGroupChar = null;
        int currentCharCount = 0;
        string result = "";

        // loop through each ch in s
        foreach (char ch in s)
        {
            // if the ch is not a letter or num
            if (!Char.IsLetterOrDigit(ch))
            {
                continue;
            }

            // if the ch matches the current character
            if (ch == currentGroupChar)
            {
                // increase count
                currentCharCount++;
            }
            else
            {
                if (currentGroupChar != null)   // null check will skip adding to result the first loop through
                {
                    // add letter and count to new string
                    result += currentGroupChar.ToString() + currentCharCount;
                }

                // current character changes to ch
                currentGroupChar = ch;

                // count resets to 1
                currentCharCount = 1;
            }
        }

        // loop ends before the last character so we add it here
        if (currentGroupChar != null && Char.IsLetterOrDigit(s[s.Length - 1]))
        {
            // add last letter and count to new string 
            result += currentGroupChar.ToString() + currentCharCount;
        }
        return result;
    }

    // checking for the last character inside the loop
    // and using a StringBuilder
    public static string EncodeRle(string s)
    {
        int currentCharCount = 1;
        var resultSb = new StringBuilder();

        // loop through each ch in s
        for (int i = 0; i <= s.Length - 1; i++)
        {
            // if current char is not a letter or num, skip it
            if (!Char.IsLetterOrDigit(s[i]))
            {
                continue;
            }

            // if current char is the last one OR it does NOT matches the next char
            if (i == s.Length - 1 || s[i] != s[i + 1])  // Note: the last char check MUST be first, or i + 1 will cause an index out of bounds error
            {
                // add letter and count to new string
                resultSb.Append(s[i].ToString() + currentCharCount);

                // count resets to 1
                currentCharCount = 1;
            }
            else
            {
                // increase count as long as s[i] and s[i + 1] are a match
                currentCharCount++;
            }
        }

        return resultSb.ToString();
    }
}
