import java.util.HashMap;

class Solution {
    private int max = Integer.MIN_VALUE;

    // функция строится как если бы мы взяли что-то одно из детей или никого из них, только себя
    // но корню разрешено брать сразу 2х детей, поэтому мы проверяем каждого на роль корня
    private int F(TreeNode cur) {
        if (cur == null) {
            return 0;
        }

        // пробуем просто взять значение без детей
        if (cur.left == null && cur.right == null) {
            max = Math.max(max, cur.val);
            return cur.val;
        }

        var leftSide = F(cur.left);
        var rightSide = F(cur.right);

        // примеряем роль корня, если в этом есть смысл
        // только корень может взять сразу 2
        if (leftSide >= 0 && rightSide >= 0) {
            max = Math.max(max, cur.val + leftSide + rightSide);
        }

        // пробуем взять одну из сторон, если мы этом есть смысл
        var result = cur.val + Math.max(0, Math.max(leftSide, rightSide));
        max = Math.max(max, result);

        return result;
    }

    public int maxPathSum(TreeNode root) {
        F(root);

        return this.max;
    }
}
