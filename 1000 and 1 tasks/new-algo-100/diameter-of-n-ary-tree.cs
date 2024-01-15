/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;
    
    public Node() {
        val = 0;
        children = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        children = new List<Node>();
    }
    
    public Node(int _val, List<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    // begin from leaves
    // f(n): f(n.l) + (0..1) + f(n.r) + (0..1)
    public int Diameter(Node root) {
        var levels = new List<List<Node>>();

        var queue = new Queue<Node>();
        queue.Enqueue(root);

        while (queue.Any()) {
            var level = new List<Node>();
            var size = queue.Count();
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                level.Add(cur);
                foreach (var c in cur.children) {
                    queue.Enqueue(c);
                }
            }
            levels.Add(level);
        }

        var result = 0;
        var scoreTable = new Dictionary<Node, int>();

        for (int i = levels.Count()-1; i >= 0; i--) {
            var level = levels[i];
            foreach (var n in level) {
                if (!n.children.Any()) {
                    scoreTable[n] = 0;
                }
                else if (n.children.Count() == 1) {
                    scoreTable[n] = 1 + scoreTable[n.children.First()];
                    result = Math.Max(result, scoreTable[n]);
                }
                else {
                    var childrenScores = n.children
                        .Select(x => scoreTable[x])
                        .OrderByDescending(x => x)
                        .ToArray();
                    scoreTable[n] = 1 + childrenScores[0];
                    result = Math.Max(result, scoreTable[n]);
                    result = Math.Max(result, 2 + childrenScores[0] + childrenScores[1]);
                }
            }
        }

        return result;
    }
}