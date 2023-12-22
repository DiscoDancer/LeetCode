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

// editorial
public class Solution {
    public class State  {
        public int nodeCount {get; set;}
        public int valueSum {get; set;}
        public double maxAverage {get; set;}

        public State(int n, int v, double m) {
            nodeCount = n;
            valueSum = v;
            maxAverage = m;
        }
    }

    private State F(TreeNode root) {
        if (root == null) {
            return new State (0,0,0);
        }

        var left = F(root.left);
        var right = F(root.right);

        int nodeCount = left.nodeCount + right.nodeCount + 1;
        int sum = left.valueSum + right.valueSum + root.val;
        double maxAverage = Math.Max(
                (1.0 * (sum)) / nodeCount, // average for current node
                Math.Max(right.maxAverage, left.maxAverage) // max average from child nodes
        );

        return new State(nodeCount, sum, maxAverage);
    }

    public double MaximumAverageSubtree(TreeNode root) {
        return F(root).maxAverage;
    }
}