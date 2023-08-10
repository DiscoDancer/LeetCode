public class Solution {
    private int _n;
    private int _k;
    private int _target;

    private long _result = 0;

    private void F(int index, int remainder) {
        if (index == _n) {
            if (remainder == 0) {
                _result++;
                _result = _result % (1_000_000_000 + 7);
            }
            return;
        }

        for (int i = 1; i <= _k; i++) {
            if (remainder - i >= 0) {
                F(index + 1, remainder - i);
            }
        }
    }

    // TL
    public int NumRollsToTarget(int n, int k, int target) {
        _target = target;
        _n = n;
        _k = k;

        F(0, target);

        return (int)_result;
    }
}