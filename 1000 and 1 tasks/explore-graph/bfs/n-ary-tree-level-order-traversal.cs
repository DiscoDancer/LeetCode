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
        var queue = new Queue<Node>();
        if (root != null) {
            queue.Enqueue(root);
        }
        
        var expectedChildren = root != null ? 1 : 0;
        var result = new List<IList<int>>();

        while (queue.Any()) {
            var list = new List<int>();
            var nextExpectedChildren = 0;
            for (int i = 0; i < expectedChildren; i++) {
                var cur = queue.Dequeue();
                list.Add(cur.val);
                foreach (var c in cur.children) {
                    queue.Enqueue(c);
                    nextExpectedChildren++;
                }
            }
            result.Add(list);
            expectedChildren = nextExpectedChildren;
        }

        return result;
    }
}