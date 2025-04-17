import java.util.ArrayList;

class Solution {

    private int max = 0;

    private int F(TreeNode cur) {
        if (cur == null) {
            return 0;
        }

        // 2 выбора, я либо беру текущий, либо нет

        // беру, значит могу взять только внуков
        var take = cur.val;
        if (cur.left != null) {
            take += F(cur.left.left) + F(cur.left.right);
        }
        if (cur.right != null) {
            take += F(cur.right.left) + F(cur.right.right);
        }

        // пропускаю
        var skip = F(cur.left) + F(cur.right);


        return Math.max(take, skip);
    }

    public int rob(TreeNode root) {

        return F(root);
    }
}
