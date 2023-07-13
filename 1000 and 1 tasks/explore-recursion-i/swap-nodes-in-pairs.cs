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

// можно попробовать рекурсию, но можно попробовать и просто по 2

public class Solution {
    public ListNode SwapPairs(ListNode head) {
        if (head?.next == null) {
            return head;
        }

        // length >= 2

        var newHead = head.next;

        var a = head;
        var b = head.next;
        var prev = (ListNode)null;

        while (true) {
            var c = b?.next;
            var d = c?.next;

            if (prev == null) {
                b.next = a;
                a.next = c;
            }
            else if (prev != null) {
                if (b != null) {
                    prev.next = b; 
                    b.next = a;
                    a.next = c;
                }
                else if (b == null) {
                    prev.next = a;
                }
            }

            if (c == null) {
                break;
            }

            prev = a;
            a = c;
            b = d;
        }

        return newHead;
    }
}