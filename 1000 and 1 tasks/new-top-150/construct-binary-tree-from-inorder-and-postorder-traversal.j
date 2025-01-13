import java.util.*;

class Solution {

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
            var leftVal = postorder[--postorderIndex];
            var left = new TreeNode(leftVal);

            // TODO find parent

            while (map.containsKey(inorder[inorderIndex]))   {
                inorderIndex--;
            }
            var parentVal = inorder[inorderIndex+1];
            var parent = map.get(parentVal);
            parent.left = left;
            map.put(leftVal, left);
            size++;


//            // пускаем inorder назад (вверх) по дереву, пока он не уйдет влево
//            while (inorderIndex < n && map.containsKey(inorder[inorderIndex])) {
//                inorderIndex--;
//            }
//
//            // теперь по той же логике мы должны уйти влево
//            var leftVal = inorder[inorderIndex];
//            var left = new TreeNode(leftVal);
//            map.put(leftVal, left);
//
//            var parentVal = inorder[inorderIndex+1];
//            var parent = map.get(parentVal);
//            parent.left = left;
//            size++;
            // break;
        }
        return root;
    }
}