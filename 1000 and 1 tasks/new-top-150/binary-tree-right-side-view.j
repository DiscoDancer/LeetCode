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

    private int maxHeight = 0;
    private Integer[] rightSideView;

    private void FindMaxHeight(TreeNode root, int height) {
        if (root == null) {
            return;
        }

        if (height > maxHeight) {
            maxHeight = height;
        }

        FindMaxHeight(root.left, height + 1);
        FindMaxHeight(root.right, height + 1);
    }

    // right inorder
    // можно за один проход заполнить список
    private void FillMaxHeight(TreeNode root, int height) {
        if (root == null) {
            return;
        }

        FillMaxHeight(root.right, height + 1);

        if (rightSideView[height] == null) {
            rightSideView[height] = root.val;
        }
        FillMaxHeight(root.left, height + 1);
    }


    public List<Integer> rightSideView(TreeNode root) {
        FindMaxHeight(root, 1);

        rightSideView = new Integer[maxHeight];
        Arrays.fill(rightSideView, null);
        FillMaxHeight(root, 0);


        return Arrays.asList(rightSideView);
    }
}