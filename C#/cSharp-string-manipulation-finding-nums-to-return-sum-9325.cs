using System;
using System.Text;

// input: string with a length from 1 to 500 characters. string contains numbers from 1 to 100 and lowercase letters.
// todo: find the numbers in the string and add them up
// output: the sum of the numbers in the input string
public class ScoreParser
{
    // FIRST ATTEMPT (worked on first try!)
    public static int SumPlayerScores(string inputString)
    {
        int sum = 0;
        var sb = new StringBuilder();

        // loop through string
        foreach (char ch in inputString)
        {
            // if a char is a number
            if (char.IsNumber(ch))
            {
                sb.Append(ch);
            }
            else
            {
                string numString = sb.ToString();

                if (!string.IsNullOrEmpty(numString))
                {
                    // parse the string to a number
                    int num = int.Parse(numString);

                    // add the number to  the sum
                    sum += num;

                    // numString becomes empty
                    sb.Clear();
                }
            }
        }

        return sum;
    }


    // NO STRING BUILDER - less efficient
    public static int SumPlayerScores(string inputString)
    {
        int sum = 0;
        string numString = "";

        // loop through string
        foreach (char ch in inputString)
        {
            // if a char is a number
            if (char.IsNumber(ch))
            {
                numString += ch;
            }
            else if (!string.IsNullOrEmpty(numString))
            {
                // parse the string to a number
                int num = int.Parse(numString);

                // add the number to  the sum
                sum += num;

                // numString becomes empty
                numString = "";
            }
        }
        return sum;
    }

    // BEST
    // REFACTORED StringBuilder version to avoid creating numString if unnecessary and adding a "sentinal"
    //      A "sentinal" is a character added to the end of a series being looped through. It is added to ensure the loop processes the triggerd logic 
    //      for the last char of the series, if it is possible for the loop to end before the logic in that loop is processed.
    //      It is a common trick in programming.
    public static int SumPlayerScores(string inputString)
    {
        int sum = 0;
        var sb = new StringBuilder();

        inputString += " ";  // Add a space to the end of the input string   

        // loop through string
        foreach (char ch in inputString)
        {
            // if a char is a number
            if (char.IsNumber(ch))
            {
                sb.Append(ch);
            }
            else if (sb.Length > 0)
            {
                // parse the string to a number
                int num = int.Parse(sb.ToString());

                // add the number to  the sum
                sum += num;

                // numString becomes empty
                sb.Clear();
            }
        }
        return sum;
    }
}
