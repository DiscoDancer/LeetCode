import java.util.*;

// проходим тест кейсы базовые, но неправильно на всем правом

class Solution {

    public TreeNode buildTree(int[] preorder, int[] inorder) {

        var n = preorder.length;

        var size = 1;
        var preorderIndex = 0;
        var inorderIndex = 0;

        var map = new HashMap<Integer, TreeNode>();

        // add root
        var root = new TreeNode(preorder[preorderIndex]);
        map.put(preorder[preorderIndex], root);


        while (size < n) {
            // phase 1: leftmost
            while (size < n && preorder[preorderIndex] != inorder[inorderIndex]) {
                preorderIndex++;
                var node = new TreeNode(preorder[preorderIndex]);
                map.put(preorder[preorderIndex], node);
                var prev = map.get(preorder[preorderIndex-1]);
                prev.left = node;
                size++;
            }

            // possible end
            if (size == n) {
                break;
            }

            // следующий в preorder будет 100% новый и он на ничего не скажет
            // да, он еще и будет правым, но не понятно относительно чего. Для этого надо смотреть в inorder.

            // пускаем inorder назад (вверх) по дереву, пока он не уйдет право
            while (inorderIndex < n && map.containsKey(inorder[inorderIndex])) {
                inorderIndex++;
            }

            // inorder теперь новый leftmost
            var parent = map.get(inorder[inorderIndex-1]);

            // но раз мы здесь, то size не поменялся и мы все еще должны уйти право
            preorderIndex++;

            var newNode = new TreeNode(preorder[preorderIndex]);
            parent.right = newNode;
            size++;
            map.put(preorder[preorderIndex], newNode);

        }

        return map.get(preorder[0]);
    }
}