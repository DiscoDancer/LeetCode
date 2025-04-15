import java.util.*;

class Solution {
    private int F(int n) {
        if (n == 1) {
            return 1;
        }
        if (n == 2) {
            return 2;
        }
        if (n == 3) {
            return 5;
        }

        var result = 0;

        for (var i = 1; i <= n; i++) {
            var leftCount = i - 1;
            var rightCount = n - i;
            result += Math.max(F(leftCount), 1) * Math.max(F(rightCount), 1);
        }

        return result;
    }

    public int numTrees(int n) {
        return F(n);
    }
}