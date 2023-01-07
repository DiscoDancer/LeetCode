public class Solution {
    public int Fib(int n) {
        if (n < 2) {
            return n;
        }

        var prevPrev = 0;
        var prev = 1;

        for (int i = 2; i <= n; i++) {
            var cur = prevPrev + prev;
            prevPrev = prev;
            prev = cur;
        }

        return prev;
    }
}