class Solution {
    public int climbStairs(int n) {
        if (n == 1) {
            return 1;
        }

        var prev = 1;
        var prevPrev = 1;

        for (int i = 1; i < n; i++) {
            var current = prev + prevPrev;
            prevPrev = prev;
            prev = current;
        }

        return prev;
    }
}
