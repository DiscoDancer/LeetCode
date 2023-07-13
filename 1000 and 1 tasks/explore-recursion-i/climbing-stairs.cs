public class Solution {
    public int ClimbStairs(int n) {
        if (n < 3) {
            return n;
        }

        var a = 1;
        var b = 2;

        for (int i = 2; i < n; i++) {
            var c = a + b;
            a = b;
            b = c;
        }

        return b;
    }
}