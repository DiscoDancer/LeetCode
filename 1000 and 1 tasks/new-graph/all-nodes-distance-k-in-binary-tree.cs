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
    // то, что внизу легко
    // parent chain
    // levels traversal
    // find not obvious, can traverse the whole tree at worst
    // level approach will help us somehow
    // lazy reroute = PROFIT (не получится, потому что нету обратной связи)
    // level approach с путями LR

    // идем по уровням и для каждого узла считаем расстояние до корня

    // пусть root -> target можно эффективно найти через backtracking

    // я могу сделать разбитие по уровням, для всех узлов выше или правее

    // можем быть, если что-то рекурсивное


    /*
        Комбинированное решение:
            - нахожу путь root -> target O(n) / O(n) / backtracking
            - идем по этому пути и заставляем исследовать не исследованную часть
    */

    private TreeNode _root;
    private TreeNode _target;

    private List<TreeNode> _path;

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
            return new List<int>() {target.val};
        }

        var result = new List<int>();

        _root = root;
        _target = target;

        FindPath(new List<TreeNode> () {root});

        var queue = new Queue<(TreeNode node, int distance)>();

        var prev = _path.Last();
        var d = 1;
        for (int i = _path.Count() - 2; i >= 0; i--) {
            var cur = _path[i];

            if (d == k) {
                result.Add(cur.val);
            }

            if (cur.left != null && cur.left != prev) {
                queue.Enqueue((cur.left, d + 1));
            }
            if (cur.right != null && cur.right != prev) {
                queue.Enqueue((cur.right, d + 1));
            }

            prev = cur;

            d++;
        }

        queue.Enqueue((target, 0));

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

        // сам путь может быть ответом

        // из _path делаем очередь на обработку
        // итерируемся по этой очереди

        return result;
    }
}