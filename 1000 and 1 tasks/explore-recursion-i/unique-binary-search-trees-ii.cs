/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {

    private Dictionary<TreeNode, TreeNode> _table;
    private TreeNode DeepCopyInner(TreeNode node) {
        if (node == null) {
            return null;
        }
        if (_table.ContainsKey(node)) {
            return _table[node];
        }

        _table[node] = new TreeNode(node.val);
        _table[node].left = DeepCopyInner(node.left);
        _table[node].right = DeepCopyInner(node.right);

        return _table[node];
    }

    private TreeNode DeepCopy(TreeNode node) {
         _table = new ();
         return DeepCopyInner(node);
    }

    private void Insert(TreeNode node, int val) {
        if (val > node.val && node.right == null) {
            node.right = new TreeNode(val);
        }
        else if (val < node.val && node.left == null ) {
            node.left = new TreeNode(val);
        }
        else if (val < node.val) {
            Insert(node.left, val);
        }
        else if (val > node.val) {
            Insert(node.right, val);
        }
    }

    private StringBuilder _sb = new StringBuilder();

    private void PreOrder(TreeNode node) {
        _sb.Append(node.val);
        if (node.left != null) {
            PreOrder(node.left);
        }
        if (node.right != null) {
            PreOrder(node.right);
        }
    }

    public IList<TreeNode> GenerateTrees(int n) {
        var list = new List<TreeNode>() {};
        var queue = new Queue<(TreeNode tree, List<int> pool)>();
        for (int i = 1; i <= n; i++) {
            var tree = new TreeNode(i);

            var pool = new List<int>();
            for (int j = 1; j <= n; j++) {
                if (i != j) {
                    pool.Add(j);
                }
            }
            queue.Enqueue((tree, pool));
        }

        while (queue.Any()) {
            var (tree, pool) = queue.Dequeue();
            if (!pool.Any()) {
                list.Add(tree);
            }
            else if (pool.Count() == 1) {
                Insert(tree, pool.First());
                list.Add(tree);
            }
            else {
                foreach(var val in pool) {
                    var copyTree = DeepCopy(tree);
                    var copyPool = pool.Where(x => x != val).ToList();
                    Insert(copyTree, val);
                    queue.Enqueue((copyTree, copyPool));
                }
            }
        }

        var table = new Dictionary<string, TreeNode>();

        foreach (var tree in list) {
            _sb = new ();
            PreOrder(tree);
            var str = _sb.ToString();
            if (!table.ContainsKey(str)) {
                table[str] = tree;
            }
        }

        // todo remove duplicates

        return table.Values.ToList();
    }
}