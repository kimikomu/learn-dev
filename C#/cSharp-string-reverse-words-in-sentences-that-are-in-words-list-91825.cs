// You are given two lists, sentences and words, each comprising n strings, where n ranges from 1 to 100 inclusive.
// Each string in the sentences list has a length ranging from 1 to 500 inclusive. Each word in the words list is a single lowercase English alphabet word of length 1 to 10 inclusive.

// Your task is to find all instances of each word in the corresponding sentence from the sentences list and replace them with the reverse of the word.
// The words and sentences at the same index in their respective lists are deemed to correspond to each other.

// Return a new list comprising n strings, where each string is the sentence from the sentences list at the corresponding index,
// with all instances of the word from the words list at the same index replaced with its reverse.

// If the word is not found in the respective sentence, keep the sentence as it is.

// Remember, while replacing the instances of the word in the sentence, you should preserve the case of the initial letter of the word.
// If a word starts with a capital letter in the sentence, its reversed form should also start with a capital letter.

// Example
// Given sentences = ["this is a simple example.", "the name is bond. james bond.", "remove every single e"] and words = ["simple", "bond", "e"],
// the output should be ["this is a elpmis example.", "the name is dnob. james dnob.", "remove every single e"].

// input: list of sentences, list of strings
// todo: replace all words in the sentences with the reveresd versions in the words list. Capitalized versions of the words in the sentences must be capitalized and reversed. Ex: Out => Tuo
// output: list of sentences with the words from words list reversed in the sentences.

using System;
using System.Text;
using System.Collections.Generic;

public class Solution
{
    // FIRST ATTEMPT
    public static List<string> Solve(List<string> sentences, List<string> words)
    {
        // list for updated sentences
        List<string> updatedSentences = new List<string>();

        // loop through pairs of sentences and words
        for (int i = 0; i < sentences.Count; i++)
        {
            var sb = new StringBuilder(sentences[i]);

            string word = words[i];
            string reversed = ReverseString(word);

            int index = sentences[i].IndexOf(word);

            // replace capitalized version of word first, if there are any
            if (sentences[i].Contains(Capitalize(word)))
            {
                index = sentences[i].IndexOf(Capitalize(word));
                string capSubString = sentences[i].Substring(index, word.Length);
                sb.Replace(capSubString, Capitalize(reversed));
            }

            // replace word with reversed
            while (index != -1)
            {
                string subString = sentences[i].Substring(index, word.Length);
                sb.Replace(subString, reversed);

                index = sentences[i].IndexOf(word, index + 1);
            }

            updatedSentences.Add(sb.ToString());
        }

        return updatedSentences;
    }

    // MUCH LESS COMPLICATED VERSION -.-
    public static List<string> Solve(List<string> sentences, List<string> words)
    {
        List<string> updatedSentences = new List<string>();

        // loop through pairs of sentences and words
        for (int i = 0; i < sentences.Count; i++)
        {
            string reversed = ReverseString(words[i]);

            sentences[i] = sentences[i].Replace(words[i], reversed);
            sentences[i] = sentences[i].Replace(Capitalize(words[i]), Capitalize(reversed));

            updatedSentences.Add(sentences[i]);
        }

        return updatedSentences;
    }

    private static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    private static string Capitalize(string word)
    {
        if (string.IsNullOrEmpty(word))
            return string.Empty;
        return char.ToUpper(word[0]) + word.Substring(1);
    }
}