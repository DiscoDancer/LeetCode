public class Solution {
    private int _n;
    private int _k;
    private int _result = 0;

    // умножать на следующие вызовы
    // void если не понятно
    private void F(int i, int prevColor, int prevPrevColor) {
        if (i == _n) {
            _result++;
            return;
        }

        for (int k = 1; k <= _k; k++) {
            if (prevColor == prevPrevColor && prevPrevColor == k) {
                continue;
            } else {
                F(i+1, k, prevColor);
            }
        }
    }

    // TL
    public int NumWays(int n, int k) {
        _n = n;
        _k = k;

        F(0, -1, -1);

        return _result;
    }
}