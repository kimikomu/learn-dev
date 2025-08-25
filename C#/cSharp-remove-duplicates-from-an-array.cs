public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int count = 2;

        if (nums.Length < 2) // Check if the array has fewer than 2 elements
        {
            return nums.Length; // Return the length of the array as no duplicates exist
        }
        
        for (int i = 2; i < nums.Length; i++)
        {    
            Console.WriteLine($"nums[i] != nums[count - 2]");
            Console.WriteLine($"nums[{i}]: {nums[i]} != nums[{count - 2}] = {nums[count - 2]}");
            if (nums[i] != nums[count - 2])
            {
                Console.WriteLine($"nums[count] = nums[i]");
                Console.WriteLine($"nums[{count}]: {nums[count]} = nums[{i}]: {nums[i]}");
                nums[count] = nums[i];
                
                count++;
            }
        }
        return count;
    }
}