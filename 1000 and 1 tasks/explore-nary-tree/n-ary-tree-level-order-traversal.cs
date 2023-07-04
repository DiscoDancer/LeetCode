/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public IList<IList<int>> LevelOrder(Node root) {
        var result = new List<IList<int>>();

        var queue = new Queue<Node>();
        if (root != null) {
            queue.Enqueue(root);
        }

        while (queue.Any()) {
            var size = queue.Count();
            var level = new List<int>();
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                foreach (var c in cur.children) {
                     queue.Enqueue(c);
                }
                level.Add(cur.val);
            }
            result.Add(level);
        }

        return result;
    }
}