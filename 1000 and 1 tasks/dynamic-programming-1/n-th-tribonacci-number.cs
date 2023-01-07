public class Solution {
    public int Tribonacci(int n) {
        if (n < 2) {
            return n;
        }
        else if (n == 2) {
            return 1;
        }

        var prevPrevPrev = 0;
        var prevPrev = 1;
        var prev = 1;

        for (int i = 3; i <= n; i++) {
            var cur = prevPrevPrev + prevPrev + prev;
            prevPrevPrev = prevPrev;
            prevPrev = prev;
            prev = cur;
        }

        return prev;
    }
}