import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Stack;

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

 // editorial idea
class Solution {

    private static int GetHeight(TreeNode root) {
        var h = 0;
        while (root != null) {
            h++;
            root = root.left;
        }
        return h;
    }

    private static boolean Exists(TreeNode node, int index, int lastLevelFullSize) {

        // convert index to binary
        var bitList = new ArrayList<Integer>();
        while (index > 0) {
            bitList.addFirst(index % 2);
            index /= 2;
        }

        var requiredLength = (int)(Math.log(lastLevelFullSize) / Math.log(2));
        while (bitList.size() < requiredLength) {
            bitList.addFirst(0);
        }

        var cur = node;
        while (!bitList.isEmpty()) {
            var bit = bitList.removeFirst();
            if (bit == 0) {
                cur = cur.left;
            }
            else {
                cur = cur.right;
            }
            if (cur == null) {
                return false;
            }
        }

        return true;
    }

    public int countNodes(TreeNode root) {
        var height = GetHeight(root);

        var lastLevelFullSize = (int)Math.pow(2, height - 1);

        var result = 0;
        for (int i = 0; i < height - 1; i++) {
            result += Math.pow(2, i);
        }

        var L = 0;
        var R = lastLevelFullSize - 1;
        while (L <= R) {
            var M = L + (R - L) / 2;
            var exists = Exists(root, M, lastLevelFullSize);
            if (exists && (M == lastLevelFullSize -1 || !Exists(root, M + 1, lastLevelFullSize))) {
                result += M  + 1;
                break;
            }
            else if (!exists) {
                R = M - 1;
            }
            else {
                L = M+1;
            }
        }
        return result;
    }
}