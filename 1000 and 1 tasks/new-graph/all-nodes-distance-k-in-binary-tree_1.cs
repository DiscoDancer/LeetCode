/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    private TreeNode _target;
    private List<TreeNode> _path;

    // через bracktracking находим путь из root -> target
    private void FindPath(List<TreeNode> path) {
        if (path.Last() == _target) {
            _path = path.ToList();
            return;
        }
        if (_path != null) {
            return;
        }

        if (path.Last().left != null) {
            var length = path.Count();
            path.Add(path.Last().left);
            FindPath(path);
            path.RemoveAt(length);
        }
        if (path.Last().right != null) {
            var length = path.Count();
            path.Add(path.Last().right);
            FindPath(path);
            path.RemoveAt(length);
        }
    }

    public IList<int> DistanceK(TreeNode root, TreeNode target, int k) {
        if (k == 0) {
            return new List<int> {target.val};
        }

        var result = new List<int>();
        
        _target = target;

        FindPath([root]);

        var queue = new Queue<(TreeNode node, int distance)>();
        queue.Enqueue((target, 0));
        
        // итерируемся по этому пути
        // ветки в которых мы не были заносим в очередь + сам путь может быть ответом
        // раз мы знаем весь путь, то знаем в какой ветке мы были (prev, cur)
        
        var prev = _path.Last();
        var d = 1;
        for (int i = _path.Count - 2; i >= 0 && d <= k; i--) {
            var cur = _path[i];

            if (d == k) {
                result.Add(cur.val);
            }
            else if (d < k)
            {
                if (cur.left != null && cur.left != prev) {
                    queue.Enqueue((cur.left, d + 1));
                }
                if (cur.right != null && cur.right != prev) {
                    queue.Enqueue((cur.right, d + 1));
                }
            }
            
            prev = cur;
            d++;
        }
        
        // каждую ветку обходим как обычно
        while (queue.Any()) {
            var (node, distance) = queue.Dequeue();
            if (distance == k) {
                result.Add(node.val);
            }
            else if (distance < k) {
                if (node.left != null) {
                    queue.Enqueue((node.left, distance + 1));
                }
                if (node.right != null) {
                    queue.Enqueue((node.right, distance + 1));
                }
            }
        }
        
        return result;
    }
}