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

    // TL
    public int NumRollsToTarget(int n, int k, int target) {
        _target = target;
        _n = n;
        _k = k;

        return (int) F(0, target);
    }
}