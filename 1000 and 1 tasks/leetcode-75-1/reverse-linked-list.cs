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

 // рекурсия помогла бы
public class Solution {
    public ListNode ReverseList(ListNode head) {
        var stack = new Stack<ListNode>();

        var p = head;
        while (p != null) {
            stack.Push(p);
            p = p.next;
        }

        var prev = (ListNode) null;
        var newHead = stack.FirstOrDefault();
        foreach (var node in stack) {
            if (prev != null) {
                prev.next = node;
            }
            node.next = null;
            prev = node;
        }

        return newHead;
    }
}