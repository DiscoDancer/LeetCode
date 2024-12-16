import java.util.Arrays;

public class Main {

    public ListNode addTwoNumbers(ListNode l1, ListNode l2) {
        var m = 0;

        var result = new ListNode(0);
        var resultHead = result;
        var resultTail = result;

        var p1 = l1;
        var p2 = l2;

        while (p1 != null && p2 != null) {
            var curSum = p1.val + p2.val + m;
            var digit = curSum % 10;
            m = curSum / 10;

            resultTail.next = new ListNode(digit);
            resultTail = resultTail.next;

            p1 = p1.next;
            p2 = p2.next;
        }

        while (p1 != null) {
            var curSum = p1.val + m;
            var digit = curSum % 10;
            m = curSum / 10;

            resultTail.next = new ListNode(digit);
            resultTail = resultTail.next;

            p1 = p1.next;
        }

        while (p2 != null) {
            var curSum = p2.val + m;
            var digit = curSum % 10;
            m = curSum / 10;

            resultTail.next = new ListNode(digit);
            resultTail = resultTail.next;

            p2 = p2.next;
        }

        if (m > 0) {
            resultTail.next = new ListNode(m);
        }

        return resultHead.next;
    }
}