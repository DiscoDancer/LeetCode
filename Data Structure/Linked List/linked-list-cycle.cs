using System.Collections.Generic;

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
    public bool HasCycle(ListNode head) {
        
        var dic = new Dictionary<ListNode, int>();
        
        var cur = head;
        
        int k = 0;
        while (cur != null) {
            if (dic.ContainsKey(cur)) {
                return true; 
            }
            dic[cur] =  k++ + 1;
            cur = cur.next;
        }
        
        return false;
    }
}