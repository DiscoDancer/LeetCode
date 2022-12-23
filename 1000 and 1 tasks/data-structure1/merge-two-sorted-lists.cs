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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        var fakeHead = new ListNode();

        var p1 = list1;
        var p2 = list2;

        var cur = fakeHead;

        while (p1 != null && p2 != null) {
            if (p1.val <= p2.val) {
                cur.next = p1;
                p1 = p1.next;
            }
            else {
                cur.next = p2;
                p2 = p2.next;
            }
            cur = cur.next;
            cur.next = null;
        }

        while (p1 != null) {
            cur.next = p1;
            p1 = p1.next;
            cur = cur.next;
            cur.next = null;
        }


        while (p2 != null) {
            cur.next = p2;
            p2 = p2.next;
            cur = cur.next;
            cur.next = null;
        }

        return fakeHead.next;
    }
}