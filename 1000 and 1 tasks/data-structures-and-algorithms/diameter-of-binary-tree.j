import java.util.*;


class Solution {

    private int max;

    private int f(TreeNode node) {
        if (node == null) {
            return 0;
        }
        if (node.left == null && node.right == null) {
            this.max = Math.max(this.max, 1);
            return 1;
        }

        var left = f(node.left);
        var right = f(node.right);

        // но мы также пытаемся взять оба
        this.max = Math.max(this.max, 1 + left + right);

        // для последующих вычислений мы берем что-то одно - левый или правый
        return 1 + Math.max(left, right);
    }

    public int diameterOfBinaryTree(TreeNode root) {

        f(root);

        // у них почему-то всегда на 1 меньше
        return this.max - 1;
    }
}