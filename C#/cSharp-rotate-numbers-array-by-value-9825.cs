// input: int array, a non-negative number k
// todo: move the nums in the array to the right k steps. end numbers should wrap around array
// output: array with rotated numbers

// ------------------ wrappedIndex = i % length -------------------------

public class Solution
{
    public void Rotate(int[] nums, int k)
    {
        int length = nums.Length;
        int[] rotate = new int[length];             // new array for rotated numbers

        for (int i = 0; i < length; i++)
        {
            int wrappedIndex = (i + k) % length;    // index where the number from nums will be placed
            rotate[wrappedIndex] = nums[i];         // put the numbers from nums into their new index in the rotate array
        }
        Array.Copy(rotate, nums, nums.Length);      // put them back into nums with their new indexes
    }
}
