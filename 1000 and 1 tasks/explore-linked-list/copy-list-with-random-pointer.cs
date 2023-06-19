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

public class Solution {
    public Node CopyRandomList(Node head) {
        if (head == null) {
            return null;
        }

        var table = new Dictionary<Node, Node>();

        var cur = head;
        while (cur != null) {
            table[cur] = new Node(cur.val);
            cur = cur.next;
        }

        cur = head;
        while (cur != null) {
            if (cur.next != null) {
                table[cur].next = table[cur.next];
            }
            if (cur.random != null) {
                table[cur].random = table[cur.random];
            }
            cur = cur.next;
        }

        return table[head];
    }
}