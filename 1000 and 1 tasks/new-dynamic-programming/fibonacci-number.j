class Solution {
    public int fib(int n) {
        if (n == 0) {
            return 0;
        }
        if (n < 3) {
            return 1;
        }

        var prev = 1;
        var prevPrev = 1;

        for (int i = 2; i < n; i++) {
            var current = prev + prevPrev;
            prevPrev = prev;
            prev = current;
        }

        return prev;
    }
}
