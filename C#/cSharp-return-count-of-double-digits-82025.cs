// You are tasked with writing a method that takes a positive integer, n, as an input and returns the number of consecutive equal digits in the number.
// Specifically, your method should identify pairs of digits in n that are equal and consecutive and return the count of these pairs.

// For instance, if n = 113224, it contains two groups of consecutive equal digits: 11 and 22. Therefore, the output should be 2.
// For n = 444, the output should also be 2, as there are two groups of 44 in this number.

// Keep in mind that n will be a positive integer ranging from 1 to 100,000,000, inclusive.
// Note: You are not permitted to convert the number into a string or any other iterable structure for this task. You should work directly with the number.


// Digit Traversal Right to Left
public class Solution
{
    // input: int btw 1 - 100,000,000 inclusive
    // todo: count equal consecutive pairs of digits in n
    // return the count of these pairs
    
    public static int CountConsecutiveEqualDigits(int n)
    {
        int pairCount = 0;
        
        while (n > 0)
        {
            // get the 2 rightmost digits - pointers
            int num = n % 10;       // Ex: n == 1234, num == 4     
            int num2 = n % 100;     // Ex: n == 1234, num2 == 34
            
            // take the last digit off of the 2nd to last number. 34 becomes 3
            num2 = num2 / 10;
            
            if (num == num2)
            {
                pairCount++;
            }
            
            // reduce n
            n = n / 10;
        }                        
        return pairCount;
    }
}
