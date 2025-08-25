// You are given an integer n where n ranges from 1 to 100,000,000, inclusive. Your task is to write a function
// that calculates and returns the product of the odd digits of n, without converting n into a string.

// For example, if n equals 43172, the output should be 21, because the product of the odd digits 3, 1, and 7 is 21.

// Please note that if n has no odd digits, your function should return 0.

// You are expected to solve this task by using a while loop. Good luck!

public class Solution
{
  // input = int n: num bt 1 - 100 million
  // get all odd nums in n and multiplied together
  // output = product of odd nums in n

  // question: if the same odd num in n appears more than once, do we multiply all of them to the sum, or just the 1st one we come across?

  public static int ProductOfOddDigits(int n)
  {
    // Initialize the product of odd digits and a flag to check for odd digits.
    int digitSum = 1;
    bool foundOddDigit = false;

    // Loop through the digits of n.
    while (n > 0)
    {
      // Extract the last digit.
      int digit = n % 10;

      // Check if the digit is odd and update the product and flag accordingly.
      if (digit % 2 == 1)
      {
        foundOddDigit = true;
        digitSum = digitSum * digit;
      }

      // Remove the last digit from n.
      n = n / 10;
    }
    // Return the product if an odd digit was found, otherwise return 0.
    if (foundOddDigit)
    {
      return (digitSum);
    }
    return 0;
  }
}
