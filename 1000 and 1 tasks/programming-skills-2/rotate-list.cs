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
    private int GetLength(ListNode head) {
        var p = head;
        int length = 0;
        while (p != null) {
            p = p.next;
            length++;
        }
        return length;
    }

    private (ListNode, ListNode) Split(ListNode head, int k) {
        var fakeHead1 = new ListNode();
        var fakeHead2 = new ListNode();

        var p1 = fakeHead1;
        var p2 = fakeHead2;

        var p = head;
        var count = 0;
        while (p != null) {
            var tmp = p;
            p = p.next;
            tmp.next = null;
            if (count < k) {
                p1.next = tmp;
                p1 = p1.next;
            }
            else {
                p2.next = tmp;
                p2 = p2.next;
            }
            count++;
        }

        return (fakeHead1.next, fakeHead2.next);
    }

    private ListNode Merge(ListNode l1, ListNode l2) {
        var fakeHead = new ListNode();
        var q = fakeHead;
        var p = l1;
        while (p != null) {
            var tmp = p;
            p = p.next;
            tmp.next = null;
            q.next = tmp;
            q = q.next;
        }

        p = l2;
        while (p != null) {
            var tmp = p;
            p = p.next;
            tmp.next = null;
            q.next = tmp;
            q = q.next;
        }

        return fakeHead.next;
    }

    public ListNode RotateRight(ListNode head, int k) {
        if (head == null) {
            return null;
        }

        var length = GetLength(head);
        k = k % length;

        var (l1, l2) = Split(head, length - k);

        return Merge(l2, l1);

        // if (length == 1 || k == 0) {
        //     return head;
        // }

    }
}