public class Solution {
    public int ClimbStairs(int n) {
        if (n < 3) {
            return n;
        }

        var prevPrev = 1;
        var prev = 2;

        for (int i = 3; i <= n; i++) {
            var cur = prevPrev + prev;
            prevPrev = prev;
            prev = cur;
        }

        return prev;
    }
}