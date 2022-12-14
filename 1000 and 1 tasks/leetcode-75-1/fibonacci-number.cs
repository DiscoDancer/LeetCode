public class Solution {
    public int Fib(int n) {
        if (n < 2) {
            return n;
        }

        var prev = 0;
        var cur = 1;
        var tmp = -1;
        for (int i = 1; i < n; i++) {
            tmp = cur;
            cur = prev + cur;
            prev = tmp;
        }

        return cur;
    }
}