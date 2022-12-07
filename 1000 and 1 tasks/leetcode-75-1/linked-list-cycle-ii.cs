/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
    public ListNode DetectCycle(ListNode head) {
        var hashSet = new HashSet<ListNode>();

        var p = head;

        while (!hashSet.Contains(p) && p != null) {
            hashSet.Add(p);
            p = p.next;
        }

        return p;
    }
}