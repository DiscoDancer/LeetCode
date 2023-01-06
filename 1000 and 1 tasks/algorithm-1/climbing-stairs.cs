public class Solution {
    public int ClimbStairs(int n) {
        var prevPrev = 1;
        var prev = 1;

        for (int i = 1; i < n; i++) {
            var cur = prev + prevPrev;
            prevPrev = prev;
            prev = cur;
        }

        return prev;
    }
}