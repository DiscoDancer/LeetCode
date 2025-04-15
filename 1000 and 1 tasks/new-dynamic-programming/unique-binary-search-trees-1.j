import java.util.*;

class Solution {
    public int numTrees(int n) {
        var table = new int[Math.max(4, n+1)];
        table[1] = 1;
        table[2] = 2;
        table[3] = 5;

        for (var i = 4; i <= n; i++) {
            var result = 0;
            for (var j = 1; j <= i; j++) {
                var leftCount = j - 1;
                var rightCount = i - j;
                result += Math.max(table[leftCount], 1) * Math.max(table[rightCount], 1);
            }
            table[i] = result;
        }

        return table[n];
    }
}