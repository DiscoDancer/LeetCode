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

    private HashSet<string> _hs = new ();
    private HashSet<string> _acceptedHs = new ();
    private List<TreeNode> _result = new ();

    private string SerializeNode(TreeNode node) {
        if (node == null) {
            return "";
        }
        var left = SerializeNode(node.left);
        var right = SerializeNode(node.right);
        var result = $"{node.val};{left};{right}";
        if (!_acceptedHs.Contains(result) && _hs.Contains(result)) {
            _result.Add(node);
            _acceptedHs.Add(result);
        }
        else {
            _hs.Add(result);
        }

        return result;
    }

    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        SerializeNode(root);

        return _result;
    }
}