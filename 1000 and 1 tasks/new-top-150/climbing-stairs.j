class Solution {
    public int climbStairs(int n) {
        if (n == 1) {
            return 1;
        }

        var prev = 1;
        var prevPrev = 1;
        var i = 1;

        while (i < n) {
            var curr = prev + prevPrev;
            var temp = prev;
            prev = curr;
            prevPrev = temp;
            i++;
        }

        return prev;
    }
}