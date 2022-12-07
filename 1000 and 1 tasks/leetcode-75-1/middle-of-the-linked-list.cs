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

 // супер тупо: хеш таблица и массив
public class Solution {
    public ListNode MiddleNode(ListNode head) {
        var p = head;
        var list = new List<ListNode>();

        while (p != null) {
            list.Add(p);
            p = p.next;
        }

        var count = list.Count();
        var middleIndex = count / 2;

        return list.ElementAt(middleIndex);
    }
}