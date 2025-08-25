// In this task, you are given a string composed of lowercase English alphabet letters ('a' to 'z'). The length of the string will range from 1 to 100 characters.
// Your challenge is to create a new string resulting from a unique order of character selection from the original string.

// You need to develop a C# function, SpecialOrder(string inputString), which takes inputString as an argument.
// The resulting string begins with the last character of the inputString, then selects the second-to-last character,
// continuing in reverse order until you reach the middle character of the string. Then, start with the first character of the inputString,
// proceed to the second character, and continue in this manner until you reach the middle character.

// For example, if the inputString is "abcdefg", the function should return "gfedabc".

// Keep in mind the following constraints while creating your function:
// The input string contains only lowercase English letters ('a' to 'z').
// The length of the input string is between 1 and 100, inclusive.

public class SolutionClass
{
    // input: string of lowercase letters between 1 - 100 inclusive
    // todo: get the reverse order of half of the string starting from the end, then get the beggining half
    // output: a new string with the letters of the input string placed in the new order


    // VERSION USING Manual Loops - Good for large amounts of data (avoids creating extra arrays/strings)
    public string SpecialOrder(string inputString)
    {
        int length = inputString.Length;

        // sanity check
        if (length == 1) { return inputString; }

        int lengthToMiddle = length / 2;
        string result = "";

        // move backwards through string and add each letter to the result until the middle is reached
        for (int i = length - 1; i > lengthToMiddle - 1; i--)
        {
            result += inputString[i];
        }

        // move from the begining of the string and add each letter to the result until the middle is reached
        for (int i = 0; i < lengthToMiddle; i++)
        {
            result += inputString[i];
        }

        return result;
    }


    // VERSION USING char[], Reverse(), and Substring() - Good for small strings
    public string SpecialOrder(string inputString)
    {
        int length = inputString.Length;

        // sanity check
        if (length == 1) { return inputString; }

        int lengthToMiddle = length / 2;
        int evenOrOdd = length % 2;         // will be 1 or 0 depending on the inputString length being an even or odd number

        // make an array of chars to reverse (since strings are immutable)
        char[] chars = inputString.ToCharArray();
        Array.Reverse(chars);

        // make a new string out of the reversed chars and only take the first half
        string reversedString = new string(chars);
        reversedString = reversedString.Substring(0, lengthToMiddle + evenOrOdd); // we'll need to add 1 if the length is odd

        // get the first half of the original inputString
        string frontHalf = inputString.Substring(0, lengthToMiddle);

        // put them together 
        return reversedString += frontHalf;
    }
}


