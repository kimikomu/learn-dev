// In this task, you are given a string s, and your goal is to produce a new string following a specific pattern. You are to take characters in sets of three,
// reverse the characters in each set, and then place them back into the string in their original positions, preserving the reverse order within each set.
// If 1 or 2 characters remain at the end (because the length of the string is not divisible by 3), they should be left as they are.

// The string s contains only lowercase English letters, with its length ranging from 1 to 300, inclusive.
// For example, if you are given the input 'abcdef', the output should be 'cbafed'. For the input 'abcdefg', your function should provide 'cbafedg'.

public static class Solution
{
    // input: string s - lowercase letters - length btw 1 - 300 inclusive
    // todo: take characters in sets of 3 and reverse the order of each set. leave remainder charachters as is
    // output: new string of sets and remainder charachters put together in order into one string

    public static string ReversedTripleChars(string s)
    {
        // create char array 
        char[] tripleChars = s.ToCharArray();
        int length = s.Length;

        // only reorganize sets of 3
        if (length >= 3)
        {
            // loop through s
            for (int i = 0; i < length - 2; i += 3)
            {
                tripleChars[i] = s[i + 2];
                tripleChars[i + 1] = s[i + 1];
                tripleChars[i + 2] = s[i];
            }
        }

        return new string(tripleChars);
    }
}
