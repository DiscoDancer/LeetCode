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

 // editorial
public class Solution {
    // расстояние до начала дикла = b
    // размер цикла = c
    // точка где нашли цикл = x
    // точка начала s

    // если пойдем от х до х, найдем размер цикла = с
    // можно найти расстояние от s до x
    public ListNode DetectCycle(ListNode head) {
        // Initialize tortoise and hare pointers
        ListNode tortoise = head;
        ListNode hare = head;

        // Move tortoise one step and hare two steps
        while (hare != null && hare.next != null) {
            tortoise = tortoise.next;
            hare = hare.next.next;

            // Check if the hare meets the tortoise
            if (tortoise == hare) {
                break;
            }
        }

        // Check if there is no cycle
        if (hare == null || hare.next == null) {
            return null;
        }

        // Reset either tortoise or hare pointer to the head
        tortoise = head;

        // Move both pointers one step until they meet again
        while (tortoise != hare) {
            tortoise = tortoise.next;
            hare = hare.next;
        }

        // Return the node where the cycle begins
        return tortoise;
    }
}