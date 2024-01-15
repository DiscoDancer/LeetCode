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
    public Node FindRoot(List<Node> tree) {
        var iAmChildrenOf = new Dictionary<int, int>();
        foreach (var n in tree) {
            foreach (var c in n.children) {
                iAmChildrenOf[c.val] = n.val;
            }
        }

        foreach (var n in tree) {
            if (!iAmChildrenOf.ContainsKey(n.val)) {
                return n;
            }
        }

        return null;
    }
}