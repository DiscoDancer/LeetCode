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
    public ListNode OddEvenList(ListNode head) {
        var oddList = new List<ListNode>();
        var evenList = new List<ListNode>();

        var p = head;
        var count = 0;
        while (p != null) {
            count++;

            var tmp = p;
            p = p.next;
            tmp.next = null;

            if (count % 2 == 1) {
                oddList.Add(tmp);
            }
            else {
                evenList.Add(tmp);
            }
        }

        var fakeHead = new ListNode();
        p = fakeHead;

        foreach (var cur in oddList) {
            p.next = cur;
            p = p.next;
        }
        foreach (var cur in evenList) {
            p.next = cur;
            p = p.next;
        }

        return fakeHead.next;
    }
}