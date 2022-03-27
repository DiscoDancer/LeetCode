using System.Collections.Generic;

/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
    public Node Connect(Node root) {
        
        if (root == null) {
            return root;
        }
        
        var queue = new Queue<Node>();
        queue.Enqueue(root);
        var list = new List<Node>();
        
        while (queue.Any()) {
            var size = queue.Count;
            
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                
                if (i < size - 1) {
                    cur.next = queue.Peek();
                }
                
                if (cur.left != null) {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null) {
                    queue.Enqueue(cur.right);
                }
            }
        }
                
        return root;
    }
}