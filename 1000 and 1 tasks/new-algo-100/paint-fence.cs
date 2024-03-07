public class Solution {

    // перебрать все варианты расскраски
    // по этим варинтам считаем 

    private List<List<int>> _allOptions = new ();
    private int _n;
    private int _k;

    private void F(int index, List<int> list, int prevColor, int prevPrevColor) {
        if (index == _n) {
            _allOptions.Add(list);
            return;
        }

        for (int color = 0; color < _k; color++) {
            var copy = list.ToList();
            copy.Add(color);

            if (color == prevColor && color == prevPrevColor)
            {
                // do nothing
            }
            else
            {
                F(index + 1, copy, color, prevColor);
            }
        }
    }

    public int NumWays(int n, int k) {
        _n = n;
        _k = k;

        F(0, new List<int>(), -1, -1);

        return _allOptions.Count;
    }
}