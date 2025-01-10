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
            // мы доходим до leftmost, inorder[0] - это leftmost
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

            // но раз мы здесь, то size не поменялся и мы все еще должны уйти право

            // следующий в preorder будет 100% новый и он нам ничего не скажет
            // да, он еще и будет правым, но не понятно относительно чего. Для этого надо смотреть в inorder.

            // пускаем inorder назад (вверх) по дереву, пока он не уйдет право
            while (inorderIndex < n && map.containsKey(inorder[inorderIndex])) {
                inorderIndex++;
            }

            // теперь inorder[inorderIndex] - это новый leftmost, который нашелся где-то вправо
            // раз он новый leftmost то рекурсия вверху сработает.

            // inorder теперь новый leftmost
            var parent = map.get(inorder[inorderIndex-1]);

            // следующий в preorder будет правым, по другому не может быть
            // суть в том, что мы таким образом сводим этот правый элемент к корню (рекурсивно или даже лучше)
            preorderIndex++;
            var newNode = new TreeNode(preorder[preorderIndex]);
            parent.right = newNode;
            size++;
            map.put(preorder[preorderIndex], newNode);
        }

        // 0ой в preorder всегда root
        return map.get(preorder[0]);
    }
}