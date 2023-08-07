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
    
    public int GCD(int a, int b)
    {
        if (a < b)
        {
            return GCD(b, a);
        }
        
        while (b != 0)
        {
            var t = b;
            b = a % b;
            a = t;
        }
        
        return a;
    }
    
    public ListNode InsertGreatestCommonDivisors(ListNode head) {
         if (head?.next == null)
        {
            return head;
        }
        
        var prev = head.val;

        var fakeHeadGCD = new ListNode();
        var fakeTailGCD = fakeHeadGCD;

        var cur = head.next;
        while (cur != null)
        {
            var gcd = GCD(prev, cur.val);
            prev = cur.val;
            cur = cur.next;

            fakeTailGCD.next = new ListNode(gcd);
            fakeTailGCD = fakeTailGCD.next;
        }

        var gcdHead = fakeHeadGCD.next;

        var p1 = gcdHead;
        var p2 = head;
        var fakeResultHead = new ListNode();
        var fakeResultTail = fakeResultHead;

        while (p1 != null)
        {
            var a = p2;
            p2 = p2.next;
            a.next = null;
            fakeResultTail.next = a;
            fakeResultTail = fakeResultTail.next;

            var b = p1;
            p1 = p1.next;
            b.next = null;
            fakeResultTail.next = b;
            fakeResultTail = fakeResultTail.next;
        }

        var c = p2;
        p2 = p2.next;
        c.next = null;
        fakeResultTail.next = c;
        fakeResultTail = fakeResultTail.next;

        return fakeResultHead.next;
    }
}