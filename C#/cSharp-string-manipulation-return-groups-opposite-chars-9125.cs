using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public class Solution
{
    // input: a string of words separated by whitespace btw 1 and 100 words. letters in words are lowercase and uppercase
    // todo: replace each letter in each word with its opposite letter in the alphabet, case sensitive ('a' to 'z', 'B' to 'Y', ect.) shift words to left. last word becomes first
    // output: a new string with the words shifted to the left, and the characters changed to their opposite in the alphabet

    // question: Do I need to account for other characters besides letters? Answer: No
    

    // FIRST PASS USING LOOPS
    public static string TransformString(string inputStr)
    {
        string[] words = inputStr.Split();
        string[] rotated = new string[words.Length];

        // rotate words from inputStr
        rotated[0] = words[words.Length - 1];
        Array.Copy(words, 0, rotated, 1, words.Length - 1);

        // new list for new words with opposite chars
        List<string> oppWords = new List<string>();

        foreach (string word in rotated)
        {
            var sb = new StringBuilder();

            foreach (char asciiChar in word)
            {
                char aInAscii = Char.IsUpper(asciiChar) ? 'A' : 'a';

                int diff = asciiChar - aInAscii;        // asciiChar will always be >= the letter 'a' or 'A' in ASCii. diff btw 0 - 25

                int charNum = aInAscii - diff + 25;     // Ex: 'a' == 97 | asciiChar('c') == 100 | diff btw 'c' and 'a' == 3 (100 - 97)
                                                        // 97 - 3 + 25 =  119('w')
                                                        // difference btw 'c' and 'a' == 3 | difference btw 'w' and 'z' == 3
                sb.Append((char)charNum);
            }

            oppWords.Add(sb.ToString());
        }

        return String.Join(" ", oppWords);
    }
}
