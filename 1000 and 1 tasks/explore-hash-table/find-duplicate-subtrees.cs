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
    // обходим каждый node
    // от каждого node делаем обход в строку и пишем в табличку
    // вот только это будет квадрат
    // в строчку не посто значения а LRV и что-то такое
    // мб если заранее каждый node засериализовать, то эффективнее
    // если идем снизу вверх, то не квадрат, а n
    // то есть с меморизацией прогнать DFS

    
    private Dictionary<TreeNode, string> _table = new ();
    private Dictionary<string, List<TreeNode>> _reverseTable = new ();

    private string SerializeNode(TreeNode node) {
        if (node == null) {
            return "";
        }
        if (_table.ContainsKey(node)) {
            return _table[node];
        }

        var left = SerializeNode(node.left);
        var right = SerializeNode(node.right);
        var result = $"{node.val};L{left};R{right}";
        _table[node] = result;
        if (!_reverseTable.ContainsKey(result)) {
            _reverseTable[result] = new ();
        }
        _reverseTable[result].Add(node);

        return result;
    }

    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        SerializeNode(root);

        var result = new List<TreeNode>();
        foreach (var v in _reverseTable.Values) {
            if (v.Count() > 1) {
                result.Add(v.First());
            }
        }

        return result;
    }
}