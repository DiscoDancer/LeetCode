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
    private List<TreeNode> _result = new ();
    private Dictionary<string, int> _tripletToID = new ();
    // We maintain one more hash map cnt (similar to the previous approach), that tracks how many times each ID occurred
    private Dictionary<int, int> _count = new ();

    // editorial

    private int F(TreeNode node) {
        if (node == null) {
            return 0;
        }

        var str = $"{F(node.left)};{node.val};{F(node.right)};";
        if (!_tripletToID.ContainsKey(str)) {
            _tripletToID[str] = _tripletToID.Count() + 1;
        }
        var id = _tripletToID[str];
        if (!_count.ContainsKey(id)) {
            _count[id] = 0;
        }
        _count[id]++;
        if (_count[id] == 2) {
            _result.Add(node);
        }

        return id;
    }

    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        F(root);
        return _result;
    }
}