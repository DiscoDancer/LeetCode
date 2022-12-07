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

// мой код, только определяет есть ли цикл, но не находит его
// раъеднять связи
// можно запоминать солько прошел slow


// не засчитали разъединение списка
public class Solution {
    public ListNode DetectCycle(ListNode head) {
        var fast = head;
        var slow = head;

        var hasCicle = false;
        while (slow != null && !hasCicle) {
            if (fast != null) {
                fast = fast.next;
            }
            if (fast != null) {
                fast = fast.next;
            }
            if (fast == slow) {
                hasCicle = true;
            }
            slow = slow.next;
        }

        if (!hasCicle) {
            return null;
        }

        var p = head;
        var prev = (ListNode) null;

        while (p != null) {
            prev = p;
            p = p.next;
            if (p.next == null) {
                return p;
            }
            prev.next = null;
        }

        return null;
    }
}