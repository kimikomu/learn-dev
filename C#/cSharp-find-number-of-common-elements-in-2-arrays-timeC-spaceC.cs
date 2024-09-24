// You are given two integer arrays nums1 and nums2 of sizes n and m, respectively. Calculate the following values:
//   answer1 : the number of indices i such that nums1[i] exists in nums2.
//   answer2 : the number of indices i such that nums2[i] exists in nums1.
//   Return [answer1,answer2].


// First Try - Time complexity O(n * m)
public class Solution {
    public int[] FindIntersectionValues(int[] nums1, int[] nums2) {
        
        int[] indicies = GetIndicies(nums1, nums2);

        return indicies;
    }

    int[] GetIndicies(int[] nums1, int[] nums2)
    {
        int count1 = 0;
        int count2 = 0;

        foreach (int num in nums1)
        {
            if (nums2.Contains(num))
            {
                count1++;
            }
        }

        foreach (int num in nums2)
        {
            if (nums1.Contains(num))
            {
                count2++;
            }
        }

        return new int[] { count1, count2 };
    }
}

// Better Solution - Time complexity O(n + m)
Solution {
    public int[] FindIntersectionValues(int[] nums1, int[] nums2) {
         
        HashSet<int> set1 = new HashSet<int>(nums1);
        HashSet<int> set2 = new HashSet<int>(nums2);

        var result = new int[2];

        for(int i = 0; i < nums2.Length; ++i)
        {
            if(set1.Contains(nums2[i]))
            {
                result[1]++;
            }
        }

        for(int i = 0; i < nums1.Length; ++i)
        {
            if(set2.Contains(nums1[i]))
            {
                result[0]++;
            }
        }

        return res;
    }
}



// -- BREAKDOWN OF TIME AND SPACE COMPLEXITY --

// Time complexity O(n + m) <-- much better
Solution {
    public int[] FindIntersectionValues(int[] nums1, int[] nums2) {
        
        // Two integer arrays nums1 and nums2 of sizes n and m
        HashSet<int> set1 = new HashSet<int>(nums1);    // O(n)
        HashSet<int> set2 = new HashSet<int>(nums2);    // O(m)

        var result = new int[2];

        for(int i = 0; i < nums2.Length; ++i)    // O(m)
        {
            if(set1.Contains(nums2[i]))    // O(1) - Contains() operation on a HashSet takes average O(1) time
            {
                result[1]++;
            }
        }
        // Take the larger time complexity of first loop = O(m)


        for(int i = 0; i < nums1.Length; ++i)    // O(n)
        {
            if(set2.Contains(nums1[i]))    // O(1) - Contains() operation on a HashSet takes average O(1) time
            {
                result[0]++;
            }
        }
        // Take the larger time complexity of first loop = O(n)

        // O(n) + O(m) + O(m) +  O(n) = Time Complexity of O(n + m)

        return res;
    }
}


// Space complexity O(n + m)
Solution {
    public int[] FindIntersectionValues(int[] nums1, int[] nums2) {
        
        // The HashSet<int> created from nums1 and nums2 each requires space proportional to the number of elements in the arrays.
        HashSet<int> set1 = new HashSet<int>(nums1);    // O(n)
        HashSet<int> set2 = new HashSet<int>(nums2);    // O(m)

        // The result array is a fixed-size array of 2 integers, so its space complexity is O(1).
        var result = new int[2];

        // The space complexity is dominated by the HashSet objects, which require O(n) + O(m)
        // Therefore, the overall space complexity is O(n + m).

        for(int i = 0; i < nums2.Length; ++i)
        {
            if(set1.Contains(nums2[i]))
            {
                result[1]++;
            }
        }

        for(int i = 0; i < nums1.Length; ++i)
        {
            if(set2.Contains(nums1[i]))
            {
                result[0]++;
            }
        }

        return res;
    }
}