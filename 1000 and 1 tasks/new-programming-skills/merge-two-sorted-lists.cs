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
        if (list1 == null) {
            return list2;
        }
        if (list2 == null) {
            return list1;
        }

        var fakeHead = new ListNode(-1);
        var fakeTail = fakeHead;

        var p = list1;
        var q = list2;

        while (p != null || q != null) {
            if (p != null && q != null) {
                if (p.val <= q.val) {
                    fakeTail.next = p;
                    p = p.next;
                }
                else {
                    fakeTail.next = q;
                    q = q.next;
                }
            }
            else if (p != null) {
                fakeTail.next = p;
                p = p.next;
            }
            else if (q != null) {
                fakeTail.next = q;
                q = q.next;
            }

            fakeTail = fakeTail.next;
            fakeTail.next = null;
        }

        return fakeHead.next;
    }
}