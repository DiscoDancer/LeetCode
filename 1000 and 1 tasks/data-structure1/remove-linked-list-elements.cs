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
    // todo filter with fake head
    public ListNode RemoveElements(ListNode head, int val) {
        var p = head;
        ListNode prev = null;
        var newHead = head;

        while (p != null) {
            if (p.val == val) {
                if (p == newHead) { // begin case
                    newHead = p.next;
                    p.next = null;
                    prev = null;
                    p = newHead;
                    continue;
                }
                else if (p.next == null) { // end case
                    prev.next = null;
                    return newHead;
                }
                else { // middle case
                    var tmp = p.next;
                    prev.next = tmp;
                    p.next = null;
                    p = tmp;
                    continue;
                }
            }

            prev = p;
            p = p.next;
        }

        return newHead;
    }
}