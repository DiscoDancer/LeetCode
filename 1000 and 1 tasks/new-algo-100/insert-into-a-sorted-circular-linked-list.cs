/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
        next = null;
    }

    public Node(int _val, Node _next) {
        val = _val;
        next = _next;
    }
}
*/

// binary search
// find head, then insert

// пропустить возрастание

public class Solution {
    public Node Insert(Node head, int insertVal) {
        if (head == null) {
            var node = new Node(insertVal);
            node.next = node;
            return node;
        }
        // [1] case
        // if (head.next == head) {
        //     var node = new Node(insertVal);
        //     head.next = node;
        //     node.next = head;
        // }

        var cur = head;
        Node prev = null;

        // если мы здесь, то cur = самый большой
        while (cur != cur.next && cur.val <= cur.next.val) {
            var prevprev = prev;
            prev = cur;
            cur = cur.next;
            if (cur == head) {
                cur = prev;
                prev = prevprev;
                break;
            }
        }

        // вставляем в конец
        if (insertVal >= cur.val) {
            var node = new Node(insertVal);
            var next = cur.next;
            // if (prev == null) {
            //     cur.next = node;
            //     node.next = cur;
            //     return head;
            // }
            cur.next = node;
            node.next = next;
            return head;
        }
        
        // теперь cur самый маленький
        prev = cur;
        cur = cur.next;

        // вставляем в начало, работает и с [1] + 0
        if (insertVal <= cur.val) {
            var node = new Node(insertVal);
            prev.next = node;
            node.next = cur;
            return head;
        }

        // если мы здесь, то ответ где-то по-середине, и длина списка минимум 2
        while (!(cur.val <= insertVal && insertVal <= cur.next.val)) {
            cur = cur.next;
        }
        var node2 = new Node(insertVal);
        var next2 = cur.next;
        cur.next = node2;
        node2.next = next2;


        return head;
    }
}