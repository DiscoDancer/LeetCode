import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {
    private ArrayList<Integer> rightSideView = new ArrayList<>();

    // right inorder
    // можно за один проход заполнить список
    private void FillMaxHeight(TreeNode root, int height) {
        if (root == null) {
            return;
        }

        FillMaxHeight(root.right, height + 1);

        while (rightSideView.size() <= height) {
            rightSideView.add(null);
        }
        if (rightSideView.get(height) == null) {
            rightSideView.set(height, root.val);
        }
        FillMaxHeight(root.left, height + 1);
    }


    public List<Integer> rightSideView(TreeNode root) {
        FillMaxHeight(root, 0);
        
        return rightSideView;
    }
}