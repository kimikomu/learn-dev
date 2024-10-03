using System;

public class Solution {
    public class TrieNode {
        
        // Children is a dictionary where the key is a character and the value is a TrieNode
        public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();

        // Indicates whether the current node marks the end of a word
        public bool IsEndOfWord { get; set; }
    }
    
    
    public class Trie {
        private readonly TrieNode root;

        public Trie ()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode current = root;

            foreach (char ch in word)
            {
                if (!current.Children.Contains(ch))
                {
                    current.Children[ch] = new TrieNode();
                }
                current = current.Children[ch];
            }

            current.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            TrieNode current = root;
            
            if (!IsPrefix(word, 1, current))
            {
                return false;
            }

            foreach (char ch in word)
            {
                current = current.Children[ch];
            }

            return current.IsEndOfWord;
        }

        // Method to check if there is any word in the trie that starts with the given prefix
        public TrieNode SearchPrefix (string prefix, out TrieNode node)
        {
            node = root;
            
            if (node == prefix.Length)
                return true;

            if (node.IsEndOfWord)
                return true;



            if (!node.Children.Contains(nextCharacter))
                return false;

            return node.Children[nextCharacter].IsPrefix(prefix, node.Children[nextCharacter])
        }
    }
}

// from prep video
using System;
using System.Collections.Generic;

public class TrieNode
{
    // Children is a dictionary where the key is a character and the value is a TrieNode
    public Dictionary<char, TrieNode> Children { get; } = new Dictionary<char, TrieNode>();

    // Indicates whether the current node marks the end of a word
    public bool IsEndOfWord { get; set; }
}

public class Trie
{
    private readonly TrieNode root;

    // Constructor to initialize the root node
    public Trie()
    {
        root = new TrieNode();
    }

    // Method to insert a word into the trie
    public void Insert(string word)
    {
        TrieNode current = root;

        foreach (char ch in word)
        {
            if (!current.Children.ContainsKey(ch))
            {
                current.Children[ch] = new TrieNode();
            }
            current = current.Children[ch];
        }

        // Mark the end of the word
        current.IsEndOfWord = true;
    }

    // Method to search for a word in the trie
    public bool Search(string word)
    {
        TrieNode current = root;

        foreach (char ch in word)
        {
            if (!current.Children.ContainsKey(ch))
            {
                return false;
            }
            current = current.Children[ch];
        }

        // Return true only if we reach the end of a word
        return current.IsEndOfWord;
    }

    // Method to check if there is any word in the trie that starts with the given prefix
    public bool StartsWith(string prefix)
    {
        TrieNode current = root;

        foreach (char ch in prefix)
        {
            if (!current.Children.ContainsKey(ch))
            {
                return false;
            }
            current = current.Children[ch];
        }

        return true;
    }