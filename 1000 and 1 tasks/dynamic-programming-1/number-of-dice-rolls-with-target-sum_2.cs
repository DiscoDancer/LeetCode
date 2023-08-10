public class Solution {
    private int _n;
    private int _k;
    private int _target;

    private long F(int index, int remainder) {
        if (index == _n) {
            if (remainder == 0) {
                return 1;
            }
            return 0;
        }

        long result = 0;
        for (int i = 1; i <= _k; i++) {
            if (remainder - i >= 0) {
                result += F(index + 1, remainder - i);
                result = result % (1_000_000_000 + 7);
            }
        }

        return result;
    }

    // accepted
    public int NumRollsToTarget(int n, int k, int target) {
        var table = new int[n+1, target +1];
        table[n,0] = 1;

        for (var index = n-1; index >= 0; index--) {
            for (var remainder = 0; remainder <= target; remainder++) {
                for (int i = 1; i <= k; i++) {
                    if (remainder - i >= 0) {
                        table[index,remainder] += table[index + 1, remainder - i];
                        table[index,remainder] = table[index,remainder] % (1_000_000_000 + 7);
                    }
                }
            }
        }


        return (int)table[0, target];

        // _target = target;
        // _n = n;
        // _k = k;

        // return (int) F(0, target);
    }
}