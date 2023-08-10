public class Solution {
    public int NumRollsToTarget(int n, int k, int target) {
        var table = new int[n+1, target +1];
        table[n,0] = 1;

        for (var index = n-1; index >= 0; index--) {
            for (var remainder = 0; remainder <= target; remainder++) {
                var i = 1;
                while (remainder - i >= 0 && i <= k) {
                    table[index,remainder] += table[index + 1, remainder - i];
                    table[index,remainder] = table[index,remainder] % (1_000_000_000 + 7);
                    i++;
                }
            }
        }


        return (int)table[0, target];
    }
}