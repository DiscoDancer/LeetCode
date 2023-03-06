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

    private ListNode Merge(ListNode list1, ListNode list2) {
        var dummyHead = new ListNode();
        var tail = dummyHead;
        while (list1 != null && list2 != null) {
            if (list1.val < list2.val) {
                tail.next = list1;
                list1 = list1.next;
                tail = tail.next;
            } else {
                tail.next = list2;
                list2 = list2.next;
                tail = tail.next;
            }
        }
        tail.next = (list1 != null) ? list1 : list2;
        return dummyHead.next;
    }

    private ListNode GetMid(ListNode head) {
        ListNode midPrev = null;
        while (head != null && head.next != null) {
            midPrev = (midPrev == null) ? head : midPrev.next;
            head = head.next.next;
        }
        var mid = midPrev.next;
        midPrev.next = null;
        return mid;
    }

    public ListNode SortList(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }
        ListNode mid = GetMid(head);
        ListNode left = SortList(head);
        ListNode right = SortList(mid);
        return Merge(left, right);
    }
}