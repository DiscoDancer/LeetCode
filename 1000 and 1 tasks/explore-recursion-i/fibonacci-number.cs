public class Solution {
    public int Fib(int n) {
        if (n < 2) {
            return n;
        }

        var a = 0;
        var b = 1;

        for (int i = 1; i < n; i++) {
            var c = a + b;
            a = b;
            b = c;
        }

        return b;
    }
}