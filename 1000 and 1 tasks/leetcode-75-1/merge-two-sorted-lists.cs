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
        var p12 = fakeHead;

        while (p1 != null || p2 != null) {
            if (p1 != null && p2 != null) {
                if (p1.val <= p2.val ) {
                    p12.next = p1;
                    p1 = p1.next;
                } else {
                    p12.next = p2;
                    p2 = p2.next;
                }
            }
            else if (p1 != null && p2 == null) {
                p12.next = p1;
                p1 = p1.next;
            }
            else if (p1 == null && p2 != null) {
                p12.next = p2;
                p2 = p2.next;
            }
            p12 = p12.next;
        }

        return fakeHead.next;
    }
}