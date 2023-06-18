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
        var fakeTail = fakeHead;

        while (list1 != null && list2 != null) {
            if (list1.val < list2.val) {
                fakeTail.next = new ListNode(list1.val);
                fakeTail = fakeTail.next;

                list1 = list1.next;
            }
            else {
                fakeTail.next = new ListNode(list2.val);
                fakeTail = fakeTail.next;

                list2 = list2.next;
            }
        }

        while (list1 != null) {
            fakeTail.next = new ListNode(list1.val);
            fakeTail = fakeTail.next;
            
            list1 = list1.next;
        }

        while (list2 != null) {
            fakeTail.next = new ListNode(list2.val);
            fakeTail = fakeTail.next;
            
            list2 = list2.next;
        }

        return fakeHead.next;
    }
}