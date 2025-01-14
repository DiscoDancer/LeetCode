import java.util.*;

class Solution {

    // СМостри https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/

    public TreeNode buildTree(int[] inorder, int[] postorder) {
        var n = inorder.length;
        var size = 1;
        var inorderIndex = n-1;
        var postorderIndex = n-1;

        var map = new HashMap<Integer, TreeNode>();
        // add root
        var root = new TreeNode(postorder[n-1]);
        map.put(postorder[n-1], root);

        while (size < n) {
            // add rightmost chain
            while (size < n && inorder[inorderIndex] != postorder[postorderIndex]) {
                postorderIndex--;
                var node = new TreeNode(postorder[postorderIndex]);
                map.put(postorder[postorderIndex], node);
                map.get(postorder[postorderIndex+1]).right = node;
                size++;
            }

            // possible end
            if (size == n) {
                break;
            }

            // следующий post order элемент - это левый элемент
            // потому что я обследовал правую цепочку от корня
            // левый точно есть, потому до этого проверка size == n
            // вопрос где он?
            var leftVal = postorder[--postorderIndex];
            var left = new TreeNode(leftVal);


            // inorder: родители идут перед правыми детьми
            // но левый элемент идет перед родителем

            // так как я читаю с конца, то все НАОБОРОТ
            // правые дети идут перед родителем
            // левые дети идут после родителя
            // нам нужно найти родителя, поэтому мы пропускаем правых детей
            // preorder до этого сунул их правых детей в map
            // сам последний родитель прочитан уже, поэтому мы переходим на следующего для inorder
            while (map.containsKey(inorder[inorderIndex]))   {
                inorderIndex--;
            }
            var parentVal = inorder[inorderIndex+1];
            var parent = map.get(parentVal);
            parent.left = left;
            map.put(leftVal, left);

            size++;
        }
        return root;
    }
}