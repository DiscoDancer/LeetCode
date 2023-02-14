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
        if (root == null) {
            return result;
        }

        var queue = new Queue<Node>();
        queue.Enqueue(root);
        var expectedNodesPerLevel = 1;


        while (queue.Any()) {
            var count = 0;
            var level = new List<int>();
            for (int i = 0; i < expectedNodesPerLevel; i++) {
                var cur = queue.Dequeue();
                level.Add(cur.val);
                foreach (var c in cur.children) {
                    queue.Enqueue(c);
                    count++;
                }
            }

            expectedNodesPerLevel = count;
            result.Add(level);
        }

        return result;
    }
}