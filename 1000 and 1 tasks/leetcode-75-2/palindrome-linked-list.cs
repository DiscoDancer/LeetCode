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

        var p = head;
        while (p != null) {
            stack.Push(p.val);
            queue.Enqueue(p.val);
            p = p.next;
        }

        while (stack.Any()) {
            if (stack.Pop() != queue.Dequeue()) {
                return false;
            }
        }

        return true;
    }
}