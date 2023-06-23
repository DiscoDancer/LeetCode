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

    private Dictionary<string, TreeNode> _result = new ();

    private string SerializeNode(TreeNode node) {
        if (node == null) {
            return "";
        }
        var left = SerializeNode(node.left);
        var right = SerializeNode(node.right);
        var serializedNode = $"{node.val};{left};{right}";
        if (_result.ContainsKey(serializedNode) && _result[serializedNode] == null) {
            _result[serializedNode] = node;
        }
        else if (!_result.ContainsKey(serializedNode)) {
            _result[serializedNode] = null;
        }

        return serializedNode;
    }

    public IList<TreeNode> FindDuplicateSubtrees(TreeNode root) {
        SerializeNode(root);

        return _result.Values.Where(x => x != null).ToList();
    }
}