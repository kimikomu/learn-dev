// You are provided with a string of n lowercase English alphabet letters (from 'a' to 'z'), where n ranges from 1 to 100, inclusive. You must create a new string
// by selecting characters from the given string in a specific order: select each character that comes k characters after the previous selection in the string.
// If you reach the end of the string, you should continue from the beginning.

// Write a C# function, RepeatCharJump(string inputString, int step). The function takes two parameters: inputString and step,
// where inputString is the string you are working with, and step is an integer that denotes the number of characters to skip with each jump.
// The value of step ranges from 1 to the length of the input string. The function should return a newly formed string consisting of characters selected
// in the order dictated by the jump length step.

// For example, if inputString is "abcdefg" and step is 3, the function should return "adgcfbe". This is because after 'a', comes 'd' (3 characters after 'a'),
// followed by 'g' (3 characters after 'd', circling back to the start of the string after 'g'), and so on.

// Note: You should continue jumping from the start of the string when you reach the end.

// For this task, assume that you need not use a character more than once. When you have traversed all the characters at least once,
// you can stop and return the output string as it is. It is guaranteed, that the inputs will be given in a way, that following the traversal pattern,
// you'll traverse all the characters.

using System;

// input: string n lowercase letters- amount btw 1 and 100 inclusive. int step - used to create pattern
// todo: select characters from n in a specific order, skipping over step amount of characters. continue to 
// select letters, looping through n until all are selected
// output: new string with new pattern of charactersfrom n

public class Solution
{
    //FIRST ATTEMPT
    public static string RepeatCharJump(string inputString, int step)
    {
        string result = "";
        int length = inputString.Length;
        int count = 1;
        int i = 0;

        while (count <= length)
        {
            result += inputString[i];
            i = (i + step) % length;    // wrap around if needed

            count++;
        }

        return result;
    }


    // Using a Bool Array
    // makes sure each character is only visited once
    public static string RepeatCharJump(string inputString, int step)
    {
        string result = "";
        int i = 0;
        int length = inputString.Length;
        bool[] visited = new bool[length];

        // keep looping as long as the current character at index i has not been used yet.
        while (!visited[i])
        {
            visited[i] = true;  // keep track of visited character

            result += inputString[i];
            i = (i + step) % length;    // wrap around if needed
        }

        return result;
    }
}