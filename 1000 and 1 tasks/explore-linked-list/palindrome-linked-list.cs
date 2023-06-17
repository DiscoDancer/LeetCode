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
    public bool IsPalindrome(ListNode head) {
        var stack = new Stack<int>();
        var queue = new Queue<int>();

        var cur = head;
        while (cur != null) {
            stack.Push(cur.val);
            queue.Enqueue(cur.val);
            cur = cur.next;
        }

        while (stack.Any()) {
            if (stack.Pop() != queue.Dequeue()) {
                return false;
            }
        }

        return true;
    }
}