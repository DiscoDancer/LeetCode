import java.util.*;

class Solution {

    // 2 прохода легко  решают задачу (длина + удаление)
    // 1 проход - находим и смещаем

    public ListNode removeNthFromEnd(ListNode head, int n) {

        ListNode targetPointer = head;
        ListNode targetPointerPrev = null;
        var targetIndex = 1;
        var p = head;
        var currentIndex = 1;
        while (p != null) {

            var distance = currentIndex - targetIndex;
            if (distance >= n) {
                targetPointerPrev = targetPointer;
                targetPointer = targetPointer.next;
                targetIndex++;
            }

            p = p.next;
            currentIndex++;
        }

        if (targetPointer == head) {
            return head.next;
        }

        targetPointerPrev.next = targetPointer.next;
        return head;
    }
}