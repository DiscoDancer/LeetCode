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
            if (!table.ContainsKey(cur)) {
                table[cur] = new Node(cur.val);
            }
            if (cur.next != null) {
                if (!table.ContainsKey(cur.next)) {
                    table[cur.next] = new Node(cur.next.val);
                }
                table[cur].next = table[cur.next];
            }
            if (cur.random != null) {
                if (!table.ContainsKey(cur.random)) {
                    table[cur.random] = new Node(cur.random.val);
                }
                table[cur].random = table[cur.random];
            }
            cur = cur.next;
        }

        return table[head];
    }
}