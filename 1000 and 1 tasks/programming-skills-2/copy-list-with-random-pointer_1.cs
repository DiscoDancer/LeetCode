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
    private Dictionary<Node, Node> _resultTable = new ();

    private Node GetClone(Node node) {
        if (node == null) {
            return node;
        }

        if (_resultTable.ContainsKey(node)) {
            return _resultTable[node];
        }
        else {
            _resultTable[node] = new Node(node.val);
            return _resultTable[node];
        }
    }

    public Node CopyRandomList(Node head) {
        if (head == null) {
            return head;
        }

        var newHead = new Node(head.val);
        _resultTable[head] = newHead;

        var p = head;
        while (p != null) {
            newHead.next = GetClone(p.next);
            newHead.random = GetClone(p.random);

            p = p.next;
            newHead = newHead.next;
        }

        return GetClone(head);
    }
}