import java.util.*;


class Solution {
    public int closestValue(TreeNode root, double target) {
        var node = root;

        double minDiff = Double.MAX_VALUE;
        int minValue = -1;

        while (node != null) {
            // update best result
            if (Math.abs(target - node.val) == minDiff && node.val < minValue) {
                minValue = node.val;
            }
            else if (Math.abs(target - node.val) < minDiff) {
                minDiff = Math.abs(target - node.val);
                minValue = node.val;
            }

            if (node.val > target) {
                node = node.left;
            }
            else {
                node = node.right;
            }
        }

        return minValue;
    }
}