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
        var p1 = list1;
        var p2 = list2;
        var head = new ListNode();
        var cur = head;

        while (p1 != null && p2 != null) {
            if (p1.val < p2.val) {
                cur.next = p1;
                p1 = p1.next;
            }
            else {
                cur.next = p2;
                p2 = p2.next;
            }
            cur = cur.next;
        }

        while (p1 != null) {
            cur.next = p1;
            p1 = p1.next;
            cur = cur.next;
        }

        while (p2 != null) {
            cur.next = p2;
            p2 = p2.next;
            cur = cur.next;
        }

        var res = head.next;
        head.next = null;
        return res;
    }
}