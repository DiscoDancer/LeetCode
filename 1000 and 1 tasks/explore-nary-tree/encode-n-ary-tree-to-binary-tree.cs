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

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Codec {
    public TreeNode encode(Node root)
    {
        if (root == null)
        {
            return null;
        }

        var queue = new Queue<Node>();
        queue.Enqueue(root);

        var numberToNodeTable = new Dictionary<int, Node>();
        var nodeToNumberTable = new Dictionary<Node, int>();
        var numberToParentNumberTable = new Dictionary<int, int>();
        var nodeCount = 1;

        numberToNodeTable[1] = root;
        nodeToNumberTable[root] = 1;
        numberToParentNumberTable[1] = -1;
        nodeCount++;

        while (queue.Any())
        {
            var size = queue.Count();
            for (int i = 0; i < size; i++)
            {
                var parent = queue.Dequeue();

                foreach (var child in parent.children)
                {
                    numberToNodeTable[nodeCount] = child;
                    nodeToNumberTable[child] = nodeCount;
                    numberToParentNumberTable[nodeToNumberTable[child]] = nodeToNumberTable[parent];
                    nodeCount++;
                    queue.Enqueue(child);
                }
            }
        }

        var binaryTreeRoot = new TreeNode(root.val * (-1));
        var cur = binaryTreeRoot;

        for (int i = 2; i < nodeCount; i++)
        {
            var originalValue = numberToNodeTable[i].val;
            var parentId = numberToParentNumberTable[i];
            var newValue = parentId * 100000 + originalValue;
            var binaryTreeNode = new TreeNode(newValue);
            cur.left = binaryTreeNode;
            cur = cur.left;
        }

        return binaryTreeRoot;
    }

    // Decodes your binary tree to an n-ary tree.
    public Node decode(TreeNode root)
    {
        if (root == null)
        {
            return null;
        }

        var numberToNodeTable = new Dictionary<int, Node>();
        var nodeToNumberTable = new Dictionary<Node, int>();
        var numberToParentNumberTable = new Dictionary<int, int>();
        var nodeCount = 1;

        var originalRoot = new Node(root.val * (-1), new List<Node>() { });
        numberToNodeTable[1] = originalRoot;
        nodeToNumberTable[originalRoot] = 1;
        numberToParentNumberTable[1] = -1;
        nodeCount++;

        var cur = root.left;
        
        // restore tables
        while (cur != null)
        {
            var originalValue = cur.val % 100000;
            var parentId = cur.val / 100000;

            var originalNode = new Node(originalValue, new List<Node>() { });
            numberToNodeTable[nodeCount] = originalNode;
            nodeToNumberTable[originalNode] = nodeCount;
            numberToParentNumberTable[nodeCount] = parentId;
            
            nodeCount++;
            cur = cur.left;
        }
        
        // restore relationships
        foreach (var (k, v) in numberToParentNumberTable)
        {
            if (v == -1)
            {
                continue;
            }

            var child = numberToNodeTable[k];
            var parent = numberToNodeTable[v];
            
            parent.children.Add(child);
        }


        return originalRoot;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(root));