public class Solution {
    public int NumRollsToTarget(int n, int k, int target) {
        var lastRow = new int[target+1];
        lastRow[0] = 1;

        for (var index = n-1; index >= 0; index--) {
            var curRow = new int[target +1];
            for (var remainder = 0; remainder <= target; remainder++) {
                var i = 1;
                while (remainder - i >= 0 && i <= k) {
                    curRow[remainder] += lastRow[remainder - i];
                    curRow[remainder] = curRow[remainder] % (1_000_000_000 + 7);
                    i++;
                }
            }
            lastRow = curRow;
        }


        return lastRow[target];
    }
}