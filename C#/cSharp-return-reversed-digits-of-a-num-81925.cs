// Your task is to construct a function that accepts an integer n and returns the integer with the same digits as n, but in reverse order.
// You should implement your solution using a while loop.
// For instance, if the input is 12345, the output should be 54321.
// Keep in mind that n will always be a positive integer between 1 and 100,000,000.

// Do not use built-in functions that convert the integer to another data type, such as a string, to reverse it.
// Solve the problem purely using mathematical operations and loop constructs.

// Note that when the result has leading zeros, you should consider only the integer value (e.g., 1230 becomes 321 after the operation).


// Digit Traversal Right to Left
public class Solution
{
    // input: positive int n - bt 1 and 100 million inclusive
    // reverse digits in n using math operations and a while loop
    // output: return an int with the same digits as n but in reverse order and no leading 0s

    public static int ReverseDigits(int n)
    {
        int reversedNum = 0;

        while (n > 0)
        {
            // get the last digit in n
            int lastDigit = n % 10;

            // move one place to the left and add the last digit to to the new reversed num
            reversedNum = reversedNum * 10 + lastDigit;

            // divide n by 10 to shrink n
            n = n / 10;
        }
        // return reversed num
        return reversedNum;
    }
}
