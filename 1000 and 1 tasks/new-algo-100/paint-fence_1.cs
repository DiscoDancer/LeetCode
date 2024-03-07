public class Solution {

    // перебрать все варианты расскраски
    // по этим варинтам считаем 

    private int _result = 0;
    private int _n;
    private int _k;

    private void F(int index, int prevColor, int prevPrevColor) {
        if (index == _n) {
            _result++;
            return;
        }

        for (int color = 0; color < _k; color++) {
            if (color == prevColor && color == prevPrevColor)
            {
                // do nothing
            }
            else
            {
                F(index + 1, color, prevColor);
            }
        }
    }

    public int NumWays(int n, int k) {
        _n = n;
        _k = k;

        F(0, -1, -1);

        return _result;
    }
}