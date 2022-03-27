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

public class LevelNode {
    public Node node;
    public int level;
    
    public LevelNode(Node _node, int _level) {
        level = _level;
        node = _node;
    }
}

public class Solution {
    public Node Connect(Node root) {
        
        if (root == null) {
            return root;
        }
        
        var queue = new Queue<LevelNode>();
        queue.Enqueue(new LevelNode(root, 0));
        
        var dic = new Dictionary<int, List<Node>>();
            
        int max = -1;
        
        while (queue.Any()) {
            var cur = queue.Dequeue();
            
            if (cur.level > max) max = cur.level;
            if (!dic.ContainsKey(cur.level)) {
                dic[cur.level] = new List<Node>();
            }
            dic[cur.level].Add(cur.node);
            
            if (cur.node.left != null) {
                queue.Enqueue(new LevelNode(cur.node.left, cur.level + 1));
            }
            if (cur.node.right != null) {
                queue.Enqueue(new LevelNode(cur.node.right, cur.level + 1));
            }
        }
        
        for (int i = 0; i <= max; i++) {
            var arr = dic[i].ToArray();
            
            for (int j = 0; j < arr.Length - 1; j++) {
                arr[j].next = arr[j+1];
            }
            arr[arr.Length - 1].next = null;
        }
        
        return root;
    }
}