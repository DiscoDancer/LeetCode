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

// https://leetcode.com/problems/palindrome-linked-list/editorial/
public class Solution {

    private ListNode GetEndOfFirstHalf(ListNode head) {
        var fast = head;
        var slow = head;

        while (fast.next != null && fast.next.next != null) {
            fast = fast.next.next;
            slow = slow.next;
        }
        return slow;
    }

    private ListNode ReverseList(ListNode head) {
        ListNode prev = null;
        var curr = head;
        while (curr != null) {
            var nextTemp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nextTemp;
        }
        return prev;
    }

    public bool IsPalindrome(ListNode head) {
        if (head == null) return true;

        var firstHalfEnd = GetEndOfFirstHalf(head);
        var secondHalfStart = ReverseList(firstHalfEnd.next);

        // Check whether or not there is a palindrome.
        var p1 = head;
        var p2 = secondHalfStart;
        var result = true;
        while (result && p2 != null) {
            if (p1.val != p2.val) result = false;
            p1 = p1.next;
            p2 = p2.next;
        }

         // Restore the list and return the result.
        firstHalfEnd.next = ReverseList(secondHalfStart);
        return result;
    }
}