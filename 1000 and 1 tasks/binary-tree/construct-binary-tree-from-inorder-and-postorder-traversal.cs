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

    /*
        - Inorder:
            - 9 начало, мб корень
            - 3 либо родитель 9, либо его правый родственник (где-то справа)

        - Postorder (с конца):
            - 3 корень 100%
            - 
    */

    // можно идти и сначал или с конца
    // что дает факт того, что элемент до или после другого
    // последний в postorder = корень
    // inorder and postorder consist of unique values.
    // идея: собираем ограничения (одно левее другого) и тогда все станет однозначно
    // мб итеративные версии расписать? с ними еще сложнее
    // iorder левость, а postorder листиковость

// editorial
public class Solution {
    private int post_idx;
    private int[] postorder;
    private int[] inorder;
    private Dictionary<int, int> idx_map = new ();

    private TreeNode helper(int in_left, int in_right) {
        // if there is no elements to construct subtrees
        if (in_left > in_right)
            return null;
        
        // pick up post_idx element as a root
        var root_val = postorder[post_idx];
        var root = new TreeNode(root_val);

        // root splits inorder list
        // into left and right subtrees
        int index = idx_map[root_val];

        // recursion 
        post_idx--;
        // build right subtree
        root.right = helper(index + 1, in_right);
        // build left subtree
        root.left = helper(in_left, index - 1);
        return root;
    }

    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        this.postorder = postorder;
        this.inorder = inorder;

        // start from the last postorder element
        // last postorder = root;
        post_idx = postorder.Length - 1;

        for (int i = 0; i < inorder.Length; i++) {
            idx_map[inorder[i]] = i;
        }

        return helper(0, inorder.Length - 1);
    }
}