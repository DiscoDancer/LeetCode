/*
// Definition for a Node.
class Node {
    int val;
    Node next;
    Node random;

    public Node(int val) {
        this.val = val;
        this.next = null;
        this.random = null;
    }
}
*/

class Solution {
    public Node copyRandomList(Node head) {
        if (head == null) {
            return null;
        }

        // вставили на начетные позиции копии
        var cur = head;
        while (cur != null) {
            var next = cur.next;
            var newNode = new Node(cur.val);
            var tmp = cur;
            cur = next;
            tmp.next = newNode;
            newNode.next = next;
        }

        // расставил связи random
        cur = head;
        while (cur != null) {
            if (cur.random != null) {
                cur.next.random = cur.random.next;
            }
            cur = cur.next.next;
        }

        // собираю список назад
        var fakeHead = new Node(-1);
        var fakeTail = fakeHead;

        cur = head;
        while (cur != null) {
            var copy = cur.next;
            var next = cur.next.next;
            cur.next = next;
            cur = next;
            copy.next = null;
            fakeTail.next = copy;
            fakeTail = fakeTail.next;
        }

        return fakeHead.next;
    }
}