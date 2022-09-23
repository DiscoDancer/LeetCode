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
            var cur = queue.Dequeue();
            cur.next = null;
            list.Add(cur);
            
            if (cur.left != null) {
                queue.Enqueue(cur.left);
            }
            if (cur.right != null) {
                queue.Enqueue(cur.right);
            }
        }
        
        var arr = list.ToArray();
        
        if (arr.Length == 1) {
            return root;
        }
        
        var levels = System.Math.Log(arr.Length + 1, 2);
        int k = 1;
        for (int l = 2; l <= levels; l++) {
            for (int i = k; i < System.Math.Pow(2, l) - 2; i++) {
                arr[i].next = arr[i+1];
                k++;
            }
            k++;
        }
        
        return root;
    }
}