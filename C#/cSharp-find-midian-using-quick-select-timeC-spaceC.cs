using System;
using System.Text.Json;

// The QuickSelect algorithm sorts the array by putting smaller numbers on the right and larger numbers on the left until the median is in the center.
// The median number will be the one that is larger than all of the numbers to its left and smaller than all of the numbers to its right. 
// The numbers on each side of the median number don't have to be in order. They just need to be smaller on the median's left and larger on
// the median's right. Similar to QuickSort but only recurses into one partition. 

class Solution {
    public static double FindMedian(int[] nums)
    {
        int length = nums.Length;

        if (length % 2 == 1)    // odd number of elements - return middle
        {
            return QuickSelect(nums, 0, length - 1, length/2);
        }
        else
        {
            // For an even number of elements, return the average of the two middle elements.
            int leftMiddleNum = QuickSelect(nums, 0, length - 1, length/2 - 1);
            int rightMiddleNum = QuickSelect(nums, 0, length - 1, length/2);

            return (leftMiddleNum + rightMiddleNum) / 2.0;
        }
    }

    // QuickSelect function to find the k-th smallest element
    // Takes the array, the first and last index of the array, and the last index of half of the array length.
    public static int QuickSelect(int[] nums, int left, int right, int k)
    {
        if (left == right) 
            return nums[left];
        
        // Partition the array to get the pivot index
        // pivot index keeps track of where we are in the array 
        int pivotIndex = Partition(nums, left, right);

        // If the pivot index is equal to k, we found the k-th smallest element
        if (pivotIndex == k)
        {
            return nums[pivotIndex];
        }
        else if (pivotIndex > k)
        {
            // Serch the left part of the array. Rightmost index moves down.
            return QuickSelect(nums, left, pivotIndex - 1, k);
        }
        else
        {
            // Serch the right part of the array. Leftmost index moves up.
            return QuickSelect(nums, pivotIndex +  1, right, k);
        }
    }

    // Partition function similar to QuickSort - where the rearranging happens.
    // Rearranges the array so that all elements smaller than the pivot are on the left,
    // and all larger elements are on the right.
    public static int Partition(int[] nums, int leftPointer, int rightPointer)
    {
        int pivot = nums[rightPointer];   // Choose the element at the rightmost index as the pivot
        int pivotIndex = leftPointer;    // reset pivotIndex to the leftmost index

        for (int i = leftPointer; i < rightPointer; i++) // left and right pointers track our index boundaries
        {
            // Compare each number at index i to the number at the rightmost index to see if it needs to move down
            if (nums[i] < pivot)
            {
                Swap(nums, i, pivotIndex); // send indexes to swap function to swap their elements
                pivotIndex++;   // move up the leftmost index by 1
            }
        }

        // pivotIndex becomes the rightmost index element
        Swap(nums, pivotIndex, rightPointer);

        return pivotIndex;
    }

    // Helper function to swap two elements in an array
    public static void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    // Inputs and Testing
    public static void Main()
    {
        int[] numsOdd = { 23, 70, 18, 99, 26, 10, 96, 52, 11, 83, 84, 25, 59, 71, 27, 44, 34, 99, 63, 39, 
            70, 48, 18, 68, 29, 77, 52, 52, 14, 30, 4, 56, 84, 47, 53, 56, 74, 4, 72, 90, 
            71, 35, 10, 76, 67, 51, 84, 22, 81, 95, 73, 21, 41, 100, 88, 72, 56, 54, 28, 
            50, 45, 92, 80, 1, 69, 81, 71, 74, 16, 67, 13, 66, 86, 67, 29, 18, 35, 88, 58, 
            42, 3, 67, 5, 64, 29, 92, 27, 6, 24, 76, 89, 80, 6, 70, 63, 41, 75, 4, 19};

        Console.WriteLine("Median of odd array: " + FindMedian(numsOdd));

        int[] numsEven = { 23, 70, 18, 99, 26, 10, 96, 52, 11, 83, 84, 25, 59, 71, 27, 44, 34, 99, 63, 39, 
            70, 48, 18, 68, 29, 77, 52, 52, 14, 30, 4, 56, 84, 47, 53, 56, 74, 4, 72, 90, 
            71, 35, 10, 76, 67, 51, 84, 22, 81, 95, 73, 21, 41, 100, 88, 72, 56, 54, 28, 
            50, 45, 92, 80, 1, 69, 81, 71, 74, 16, 67, 13, 66, 86, 67, 29, 18, 35, 88, 58, 
            42, 3, 67, 5, 64, 29, 92, 27, 6, 24, 76, 89, 80, 6, 70, 63, 41, 75, 4, 19, 1, 81, 30};

        Console.WriteLine("Median of even array: " + FindMedian(numsEven));
    }
}


// Time complexity - Average is O(n). Works efficiently in practice by focusing on only one partition and discarding the rest.
// Worst case is O(n^2), but this happens rarely, and you can mitigate it by using random pivot selection.

// Space complexity - O(1) if we use an in-place partitioning method, and we don't create extra arrays for sorting.













// Version with logs for testing purposes
class Solution {
    public static double FindMedian(int[] nums)
    {
        int length = nums.Length;

        if (length % 2 == 1)    // odd number of elements - return middle
        {
            return QuickSelect(nums, 0, length - 1, length/2);
        }
        else
        {
            // For an even number of elements, return the average of the two middle elements.
            int leftMiddleNum = QuickSelect(nums, 0, length - 1, length/2 - 1);
            int rightMiddleNum = QuickSelect(nums, 0, length - 1, length/2);

            return (leftMiddleNum + rightMiddleNum) / 2.0;
        }
    }

    // QuickSelect function to find the k-th smallest element ()
    public static int QuickSelect(int[] nums, int left, int right, int k)
    {
        if (left == right) 
            return nums[left];

        Console.WriteLine($"smallest section: {k}");
        
        // Partition the array to get the pivot index
        int pivotIndex = Partition(nums, left, right);

        // If the pivot index is equal to k, we found the k-th smallest element
        if (pivotIndex == k)
        {
            return nums[pivotIndex];
        }
        else if (pivotIndex > k)
        {
            // Serch the left part of the array
            return QuickSelect(nums, left, pivotIndex - 1, k);
        }
        else
        {
            // Serch the right part of the array
            return QuickSelect(nums, pivotIndex +  1, right, k);
        }

    }

    // Partition function similar to QuickSort
    // Rearranges the array so that all elements smaller than the pivot are on the left,
    // and all larger elements are on the right.
    public static int Partition(int[] nums, int leftPointer, int rightPointer)
    {
        // Choose the rightmost element as pivot
        int pivot = nums[rightPointer];
        int pivotIndex = leftPointer;

        for (int i = leftPointer; i < rightPointer; i++)
        {
            if (nums[i] < pivot)
            {
                Console.WriteLine("----");
                Console.WriteLine($"number at index {i}! - {nums[i]} is less than {pivot}: swapping {i} with {pivotIndex}");
                Swap(nums, i, pivotIndex);
                pivotIndex++;
                Console.WriteLine($"new number at {i} is {nums[i]}, pivotIndex: {pivotIndex}");
                string json = JsonSerializer.Serialize(nums);
                Console.WriteLine(json);
            }
            Console.Write($"    index {i}.");
        }

        // Swap the pivot element with the element at pivotIndex
        Swap(nums, pivotIndex, rightPointer);

        // Console.WriteLine("");
        // Console.WriteLine($"--- After Swap! pivotIndex: {pivotIndex} ---");
        // Console.WriteLine($"leftmost index: {left}, rightmost index: {right}, number at rightmost index: {nums[i]}");
        // string jsonString = JsonSerializer.Serialize(nums);
        // Console.WriteLine(jsonString);

        return pivotIndex;
    }

    // Helper function to swap two elements in an array
    public static void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    // Inputs and Testing
    public static void Main()
    {
        int[] numsOdd = { 23, 70, 18, 99, 26, 10, 96, 52, 11, 83, 84, 25, 59, 71, 27, 44, 34, 99, 63, 39, 
70, 48, 18, 68, 29, 77, 52, 52, 14 };
// 30, 4, 56, 84, 47, 53, 56, 74, 4, 72, 90, 
// 71, 35, 10, 76, 67, 51, 84, 22, 81, 95, 73, 21, 41, 100, 88, 72, 56, 54, 28, 
// 50, 45, 92, 80, 1, 69, 81, 71, 74, 16, 67, 13, 66, 86, 67, 29, 18, 35, 88, 58, 
// 42, 3, 67, 5, 64, 29, 92, 27, 6, 24, 76, 89, 80, 6, 70, 63, 41, 75, 4, 19 };
;
        Console.WriteLine("Median of odd array: " + FindMedian(numsOdd));

//         int[] numsEven = { 23, 70, 18, 99, 26, 10, 96, 52, 11, 83, 84, 25, 59, 71, 27, 44, 34, 99, 63, 39, 
// 70, 48, 18, 68, 29, 77, 52, 52, 14, 30, 4, 56, 84, 47, 53, 56, 74, 4, 72, 90, 
// 71, 35, 10, 76, 67, 51, 84, 22, 81, 95, 73, 21, 41, 100, 88, 72, 56, 54, 28, 
// 50, 45, 92, 80, 1, 69, 81, 71, 74, 16, 67, 13, 66, 86, 67, 29, 18, 35, 88, 58, 
// 42, 3, 67, 5, 64, 29, 92, 27, 6, 24, 76, 89, 80, 6, 70, 63, 41, 75, 4, 19, 1, 81, 30};

//         Console.WriteLine("Median of even array: " + FindMedian(numsEven));
    }
}
