/*
// Definition for a Node.
public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;
}
*/

public class Solution {
    public Node Flatten(Node head) {
        var stack = new Stack<Node>();

        var fakeHead = new Node();
        var fakeTail = fakeHead;

        var cur = head;
        while (cur != null || stack.Any()) {
            if (cur == null) {
                cur = stack.Pop();
            }

            // разрушаем связи кладем в конец
            if (cur.child == null) {
                var tmp = cur;
                cur = cur.next;

                tmp.next = null;
                tmp.prev = null;
                tmp.child = null;

                fakeTail.next = tmp;
                tmp.prev = fakeTail;
                fakeTail = fakeTail.next;
            }
            else {
                // следующий в stack
                var next = cur.next;
                if (next != null) {
                    next.prev = null;
                    stack.Push(next);
                }

                var tmp = cur;
                cur = cur.child;

                tmp.next = null;
                tmp.prev = null;
                tmp.child = null;

                fakeTail.next = tmp;
                tmp.prev = fakeTail;
                fakeTail = fakeTail.next;
            }
        }
        
        var result = fakeHead.next;
        if (result != null) {
            result.prev = null;
        }

        return result;
    }
}