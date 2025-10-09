using System;
using System.Collections.Generic;


// input: 2 lists of tuples: Lists<(int, string)> - source strings = alphanumeric chars w lengths from 1 to 100. search strings length from 1 to 500.
// todo: find string in sourceArray == substring in searchArray, && int with string in sourceArray <= int with the matching substring in searchArray 
// output: list of tuples with matches in the same order as sourceArray
public class Solution
{
    // FIRST ATTEMPT - Nested loops brute force. Not sure if there is a better way to do this
    public static List<(int, string)> StringSearch(List<(int, string)> sourceArray, List<(int, string)> searchArray)
    {
        List<(int, string)> result = new List<(int, string)>();

        // loop through source
        foreach ((int, string) sourceTup in sourceArray)
        {
            // loop through search
            foreach ((int, string) searchTup in searchArray)
            {
                // if source string is substring && source int <= search int
                if (searchTup.Item2.Contains(sourceTup.Item2))
                {
                    if (searchTup.Item1 >= sourceTup.Item1)
                    {
                        result.Add(sourceTup);
                        break;
                    }
                }
            }
        }
        return result;
    }
}
