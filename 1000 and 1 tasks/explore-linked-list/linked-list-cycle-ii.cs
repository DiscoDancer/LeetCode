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
        var hs = new HashSet<ListNode>();

        var cur = head;
        while (cur != null) {
            if (hs.Contains(cur)) {
                return cur;
            }
            hs.Add(cur);
            cur = cur.next;
        }

        return null;
    }
}