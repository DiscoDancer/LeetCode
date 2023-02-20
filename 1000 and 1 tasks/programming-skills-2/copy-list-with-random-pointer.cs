/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

// random can point to any or null
// do deep copy
// рестр номеров: Node -> int
public class Solution {
    public Node CopyRandomList(Node head) {
        if (head == null) {
            return null;
        }

        // Node -> number
        var registry = new Dictionary<Node, int>();
        int count = 0;
        var p = head;
        while (p != null) {
            registry[p] = count++;
            p = p.next;
        }

        // copy without random
        p = head;
        var fakeNewHead = new Node(-1);
        var q = fakeNewHead;
        var newRegistry = new Node[count];
        count = 0;
        while (p != null) {
            q.next = new Node(p.val);
            newRegistry[count++] = q.next;
            p = p.next;
            q = q.next;
        }

        p = head;
        while (p != null) {
            if (p.random != null) {
                var from = registry[p];
                var to = registry[p.random];

                newRegistry[from].random = newRegistry[to];
            }
            p = p.next;
        }

        return fakeNewHead.next;
    }
}