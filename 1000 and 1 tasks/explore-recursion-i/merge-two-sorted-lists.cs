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
            var tmp = (ListNode)null;
            if (list1.val < list2.val) {
                tmp = list1;
                list1 = list1.next;
            }
            else {
                tmp = list2;
                list2 = list2.next;
            }
            fakeTail.next = tmp;
            tmp.next = null;
            fakeTail = fakeTail.next;
        }

        while (list1 != null) {
            var tmp = list1;
            list1 = list1.next;
            fakeTail.next = tmp;
            tmp.next = null;
            fakeTail = fakeTail.next;
        }

        while (list2 != null) {
            var tmp = list2;
            list2 = list2.next;
            fakeTail.next = tmp;
            tmp.next = null;
            fakeTail = fakeTail.next;
        }


        return fakeHead.next;
    }
}