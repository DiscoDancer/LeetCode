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

// я решил сам, помогла картинка

public class Solution {
    // если кто-то равен, сразу вставляем за ним
    // min max найти 
    // диапозон
    // можно цикл искать HashSet, но достаточно просто повторяющеся найти? (нет)
    // мб найти начало
    // крейзи - отсортировать и поставить назад
    // цикл - от head пришли в head
    public Node Insert(Node head, int insertVal) {
        // пусто
        if (head == null) {
            var newHead = new Node(insertVal);
            newHead.next = newHead;

            return newHead;
        }
        
        // только один
        if (head.next == null) {
            var newNode = new Node(insertVal);
            head.next = newNode;
            newNode.next = head;

            return head;
        }

        // больше 1

        var cur = head.next;
        // минимум будет стартом
        var min = head;
        var max = head;

        while (cur != head) {
            min = min.val <= cur.val ? min : cur;
            max = max.val <= cur.val ? cur : max;
            cur = cur.next;
        }

        cur = min;
        var next = cur.next;

        // cur <= next
        while (next != min) {
            if (insertVal >= cur.val && insertVal <= next.val) {
                var node = new Node(insertVal);
                cur.next = node;
                node.next = next;
                return head;
            }

            cur = cur.next;
            next = next.next;
        }

        // cur >= next
        // если дошли до сюда -> новый либо максимум, либо минимум
        var newMaxMin = new Node(insertVal);
        cur.next = newMaxMin;
        newMaxMin.next = next;

        return head;
    }
}