// Given the head of a singly linked list, return the middle node of the linked list.
// If there are two middle nodes, return the second middle node.

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode MiddleNode(ListNode head) {
        
        // Both pointers start at the beginning
        var middle = head;
        var end = head;

        while (end != null && end.next != null) // end pointer stops before null reference
        {
            middle = middle.next;
            end = end.next.next;
        }
               
        return middle;
    }
}

// Input: head = [1,2,3,4,5]
// Expected: [3,4,5]
// Explanation: The middle node of the list is node 3.

// Input: head = [1,2,3,4,5,6]
// Expected: [4,5,6]
// Explanation: Since the list has two middle nodes with values 3 and 4, we return the second one.
