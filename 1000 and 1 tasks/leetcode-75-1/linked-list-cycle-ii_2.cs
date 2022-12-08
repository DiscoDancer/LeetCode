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

        ListNode intersect = null;

        while (fast?.next != null && intersect == null) {
            fast = fast.next.next;
            slow = slow.next;
            if (slow == fast) {
                intersect = slow;
            }
        }

        if (intersect == null) {
            return null;
        }

        var p1 = head;
        var p2 = intersect;

        while (p1 != p2) {
            p1 = p1.next;
            p2 = p2.next;
        }

        return p1;
    }
}