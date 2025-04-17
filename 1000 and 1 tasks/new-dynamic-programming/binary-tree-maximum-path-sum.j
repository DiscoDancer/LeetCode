import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;

class Solution {

    private HashMap<TreeNode, Integer> map = new HashMap<>();
    private int maxPretendToBeRoot = Integer.MIN_VALUE;

    // функция строится как если бы мы взяли что-то одно из детей или никого из них, только себя
    // но корню разрешено брать сразу 2х детей, поэтому мы проверяем каждого на роль корня
    private int F(TreeNode cur) {
        if (cur == null) {
            return 0;
        }
        if (cur.left == null && cur.right == null) {
            map.put(cur, cur.val);
            return cur.val;
        }

        var leftSide = F(cur.left);
        var rightSide = F(cur.right);

        if (leftSide >= 0 && rightSide >= 0) {
            var result = cur.val + leftSide + rightSide;
            maxPretendToBeRoot = Math.max(maxPretendToBeRoot, result);
        }

        var maxSide = Math.max(0, Math.max(leftSide, rightSide));
        var result = cur.val + maxSide;
        map.put(cur, result);
        return result;
    }

    public int maxPathSum(TreeNode root) {
        F(root);

        return Math.max(maxPretendToBeRoot, Collections.max(map.values()));
    }
}
