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
    public ListNode InsertionSortList(ListNode head)
    {
        if (head == null)
        {
            return null;
        }

        var result = head;
        var remainingInput = head.next;
        result.next = null;

        while (remainingInput != null)
        {
            var cur = remainingInput;
            remainingInput = remainingInput.next;
            cur.next = null;

            if (cur.val < result.val)
            {
                cur.next = result;
                result = cur;
            }
            else
            {
                var p = result;
                while (p.next != null && p.next.val < cur.val)
                {
                    p = p.next;
                }

                var tmp = p.next;
                p.next = cur;
                cur.next = tmp;
            }
        }
        
        return result;
    }
}