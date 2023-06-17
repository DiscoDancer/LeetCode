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
    // 2 списка с фильтрацией объединить
    // вместо fake можно реальные 2 взять 1ый и 2ой
    public ListNode OddEvenList(ListNode head) {
        if (head?.next == null) {
            return head;
        }
        
        var newHeadOdd = head;
        var newHeadEven = head.next;
        var cur = head.next.next;

        var newTailOdd = newHeadOdd;
        var newTailEven = newHeadEven;

        newTailEven.next = null;
        newTailOdd.next = null;

        var i = 1;
        while (cur != null) {
            var tmp = cur;
            cur = cur.next;
            tmp.next = null;
            if (i % 2 == 1) {
                newTailOdd.next = tmp;
                newTailOdd = newTailOdd.next;
            }
            else {
                newTailEven.next = tmp;
                newTailEven = newTailEven.next;   
            }
            i++;
        }

        newTailOdd.next = newHeadEven;
        return head;
    }
}