// Humans often make mistakes when they are typing quickly. In some cases, they may press two keys simultaneously,
// resulting in swapped characters in the text. Your task is to craft a C# function that helps identify such typos.
// Specifically, you are asked to construct a function called SpotSwaps that behaves as follows:

// Given two strings, source and target, of the same length n (1 ≤ n ≤ 500), inclusive, both comprised only of lowercase English letters.
// The function should return a list of tuples. Each tuple should contain three elements:
// the zero-based index of the swap in the source string, the character (a string of length 1) at that index in source,
// and the character that swapped places with the source character in target.

// In other words, go over both strings simultaneously and, for each character from source and target at position i,
// find situations when source[i] != target[i] and source[i+1] == target[i] and source[i] == target[i+1].
// This implies that the characters at positions i and i+1 in the source string swapped places in the target string.

// Note:
// Characters can be swapped at most once.
// The swapped character pairs should be returned in a list in the order they were found (from the string start to end).
// Don't check for swaps at the last position of a string since there is no character with which to swap.

// Example:
// For source = "hello" and target = "hlelo", the output should be [(1, 'e', 'l')].



using System;
using System.Collections.Generic;

// input: 2 lowercase strings of the same length.
// todo: go over both strings at the same time. find characters in the source string that are swapped with the coresponding target strings
// output: list of tuples with index of the swap in the source string, the char at that index, and the char that swapped places in the target


public class Solution
{
    // FIRST ATTEMPT
    public static List<(int, char, char)> SpotSwaps(string source, string target)
    {
        List<(int, char, char)> tuple = new List<(int, char, char)>();

        for (int i = 0; i < source.Length - 1; i++)
        {
            if (source[i] != target[i] &&
                source[i + 1] == target[i] &&
                source[i] == target[i + 1])
            {
                tuple.Add((i, source[i], target[i]));
            }
        }
        return tuple;
    }
}
