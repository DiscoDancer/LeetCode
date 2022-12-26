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

    // вопрос - надо его перестраивать или нет
    // нужно придумать когда надо
    // на вид не надо его перестраивать

    private void InsertIntoBSTInner(TreeNode root, int val) {
        if (val > root.val) { // вставляем право
            if (root.right == null) {
                root.right = new TreeNode(val);
            } else { // уже есть
                InsertIntoBST(root.right, val);
                // они не могут быть равны, либо больше, либо меньше
                // if (root.right > val) {
                //     InsertIntoBST(root.right, val);
                // }
                // else {
                //     // todo implement me
                // }
            }
        } 
        else { // вставляем влево
            if (root.left == null) {
                root.left = new TreeNode(val);
            } else {
                InsertIntoBST(root.left, val);
                // todo implement me
            }
        }
    }

    public TreeNode InsertIntoBST(TreeNode root, int val) {
        if (root == null) {
            return new TreeNode(val);
        }


        InsertIntoBSTInner(root, val);

        return root;
    }
}