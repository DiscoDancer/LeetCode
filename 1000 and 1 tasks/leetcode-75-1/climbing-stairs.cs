public class Solution {
    public int ClimbStairs(int n) {
        if (n < 3) {
            return n;
        }

        var prev2 = 1;
        var prev1 = 2;
        var tmp = -1;
        var cur = -1;
        for (int i = 2; i < n; i++) {
            tmp = prev1;
            cur = prev1 + prev2;
            prev2 = tmp;
            prev1 = cur;
        }

        return cur;
    }
}