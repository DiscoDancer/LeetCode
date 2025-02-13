/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
class Solution {

    private int length(ListNode head) {
        int len = 0;
        while (head != null) {
            len++;
            head = head.next;
        }
        return len;
    }

    // Merge Sort
    // вопрос в том, нужен ли мне конец интервала
    // я могу оперировать длиной временно
    private void F(ListNode head, int intervalLength) {
        // could be 0?
        if (intervalLength < 2) {
            return;
        }

        var lLength = intervalLength / 2;
        var hasM = intervalLength % 2 != 0;

        // sort l
        F(head, lLength);

        // sort r
        var pRight = head;
        for (int i = 0; i < lLength; i++) {
            pRight = pRight.next;
        }
        // if m exists, it comes to the right
        F(pRight, intervalLength - lLength);

        // do merge
        var pLeft = head;
        // pRight

        // доп память

        var arr = new int[intervalLength];

        var lCount = lLength;
        var rCount = intervalLength - lLength;

        for (int arrIndex = 0; arrIndex < intervalLength; arrIndex++) {
            if (lCount > 0 && rCount > 0) {
                if (pLeft.val <= pRight.val) {
                    arr[arrIndex] = pLeft.val;
                    pLeft = pLeft.next;
                    lCount--;
                } else {
                    arr[arrIndex] = pRight.val;
                    pRight = pRight.next;
                    rCount--;
                }
            } else if (lCount > 0) {
                arr[arrIndex] = pLeft.val;
                pLeft = pLeft.next;
                lCount--;
            } else {
                arr[arrIndex] = pRight.val;
                pRight = pRight.next;
                rCount--;
            }
        }

        var p = head;
        for (int i = 0; i < intervalLength; i++) {
            p.val = arr[i];
            p = p.next;
        }

//        var pLeft = head;
//        var pRight0 = pRight;
//        while (pLeft != pRight0) {
//            if (pLeft.val <= pRight.val) {
//                pLeft = pLeft.next;
//                continue;
//            }
//            if (pLeft.val > pRight.val) {
//                swap(pLeft, pRight);
//            }
//            pLeft = pLeft.next;
//            pRight = pRight.next;
//        }
    }

    public void swap(ListNode a, ListNode b) {
        var t = a.val;
        a.val = b.val;
        b.val = t;
    }

    public ListNode sortList(ListNode head) {
        var l = length(head);
        F(head, l);
        return head;
    }
}