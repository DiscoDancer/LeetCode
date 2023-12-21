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
    public ListNode PlusOne(ListNode head) {

        var stack = new Stack<ListNode>();
        var cur = head;
        while (cur != null) {
            stack.Push(cur);
            cur = cur.next;
        }

        var needToIcrease = true;
        while (needToIcrease && stack.Any()) {
            var top = stack.Pop();
            var sum = top.val + 1;
            top.val = sum % 10;
            needToIcrease = (sum / 10) > 0;
        }

        if (needToIcrease) {
            var newHead = new ListNode(1);
            newHead.next = head;
            return newHead;
        }

        return head;
    }
}