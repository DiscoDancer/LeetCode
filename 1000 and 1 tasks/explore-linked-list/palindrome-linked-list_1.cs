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
    // 2 указателя fast slow, можно найти середину
    // и пока ищем переварачиваем

    // середина 1 -> 1 ; 12 -> 1; 123 -> 2;
    // середина включается в первый список 
    // и это ок, потому что 1 и 2 надо сравнивать пока второй не кончится тогда
    private ListNode GedEndFirstHalf(ListNode head) {
        var slow = head;
        var fast = head.next;

        while (fast?.next != null) {
            fast = fast.next?.next;
            slow = slow.next;
        }

        return slow;
    }

    private ListNode ReverseList(ListNode head) {
        if (head == null) {
            return null;
        }

        var curOriginal = head;
        ListNode curNew = null;

        while (curOriginal != null) {
            var tmp = curOriginal;
            curOriginal = curOriginal.next;
            tmp.next = curNew;
            curNew = tmp;
        }

        return curNew;
    }

    public bool IsPalindrome(ListNode head) {
        if (head == null) {
            return true;
        }

        var endFirstHalf = GedEndFirstHalf(head);
        var secondHalfStart = ReverseList(endFirstHalf.next);

        var cur1 = head;
        var cur2 = secondHalfStart;
        
        while (cur1 != null && cur2 != null) {
            if (cur1.val != cur2.val) {
                return false;
            }
            cur1 = cur1.next;
            cur2 = cur2.next;
        }

        return true;
    }
}