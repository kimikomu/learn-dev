// Your task is to implement a function that duplicates every digit in a given non-negative integer number, n.
//For example, if n equals 1234, the function should return 11223344.

// To prevent possible integer overflow, it is guaranteed that n will be a non-negative integer that does not exceed 10 to the 4th power. (10000)
// Solve this task without converting n into a string or performing any other type of casting. Your job is to work strictly with integer operations.

// Keynote: Focus on the essence of the problem, which is processing each digit of the number independently while maintaining the digit order.
// There is no need to look for mathematical patterns or clever simplifications; plain and straightforward processing will suffice.
// Utilize the toolbox of basic programming skills: loops, conditions, and mathematical operations. Good luck!


// Digit Traversal Left to Right
public class Solution
{
    // input: positive int n - bt 1 and 10000 inclusive
    // duplicate each number at every digit in n using math operations only
    // output: return an int with the same digits as n but in with the number at every digit duplicated

    public static int DuplicateDigits(int n)
    {
        int result = 0;
        int divisor = 1;

        // get the highest power of 10 less than or equal to n. We'll call it divisor.
        // Ex: if n == 1234, divisor == 1000
        while (divisor * 10 <= n)
        {
            divisor = divisor * 10;
        }

        while (divisor > 0)
        {
            // get the number at the leftmost digit placement. 
            // Ex: if n == 1234 and divisor == 1000, n / divisor == 1
            int leftMostNum = n / divisor;

            // add the number to the result 2x
            // Ex: if leftmostNum == 1 and result == 0, result will equal 11
            result = result * 10 + leftMostNum;
            result = result * 10 + leftMostNum;

            // remove the leftmost number in n
            // Ex: if n == 1234 and divisor == 1000, n % divisor == 234
            n = n % divisor;

            // reduce the divisor by 10
            // Ex: if divisor == 1000, divisor / 10 == 100
            divisor = divisor / 10;
        }

        return result;
    }
}
