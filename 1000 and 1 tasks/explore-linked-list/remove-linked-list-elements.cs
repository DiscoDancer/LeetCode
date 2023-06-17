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
    public ListNode RemoveElements(ListNode head, int val) {
        if (head == null) {
            return null;
        }

        var fakeHead = new ListNode();
        var fakeTail = fakeHead;
        var cur = head;

        while (cur != null) {
            if (cur.val == val) {
                cur = cur.next;
            }
            else {
                var tmp = cur;
                cur = cur.next;
                tmp.next = null;
                fakeTail.next = tmp;
                fakeTail = fakeTail.next;
            }
        }

        return fakeHead.next;
    }
}