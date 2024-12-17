import java.util.*;

class Solution {

    public ListNode reverseBetween(ListNode head, int left, int right) {
        if (head == null) {
            return null;
        }

        var initialHead = head;
        var index = 1;
        ListNode prev = null;
        // мотаем до левой границы
        // prev - конец левой части
        while (head != null && index < left ) {
            prev = head;
            head = head.next;
            index++;
        }
        
        // неудачное имя, но это сборка реверса
        ListNode fakeHead = null;

        var p = head;
        // p0 - статем последним, поэтому он важен
        // делаем обычный reverse, но с счетчиком
        var p0 = head;
        while (p != null && index <= right) {
            var next = p.next;
            p.next = fakeHead;
            fakeHead = p;

            p = next;
            index++;
        }

        // соединяеся с правой частью
        if (p0 != p) {
            p0.next = p;
        }

        // соединяеся с левой частью (если она есть)
        if (prev != null) {
            prev.next = fakeHead;
            return initialHead;
        }
        
        // если нету левой части
        return fakeHead;
    }
}