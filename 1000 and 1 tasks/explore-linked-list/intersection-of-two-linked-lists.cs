/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        var hs = new HashSet<ListNode>();

        var cur = headA;
        while (cur != null) {
            hs.Add(cur);
            cur = cur.next;
        }

        cur = headB;
        while (cur != null) {
            if (hs.Contains(cur)) {
                return cur;
            }
            cur = cur.next;
        }

        return null;
    }
}