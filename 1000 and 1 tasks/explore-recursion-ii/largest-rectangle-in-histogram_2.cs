public class Solution {

    private int[] _heights;


    private int F(int L, int R) {
        // как не выйти за индексы?
        if (L < 0 || R < 0 || L >= _heights.Length || R >= _heights.Length || L > R) {
            return 0;
        }

        var min = _heights[L];
        var minIndex = L;
        for (int i = L+1; i <= R; i++) {
            if (_heights[i] < min) {
                min = _heights[i];
                minIndex = i;
            }
        }

        var withMinimum = (R-L+1) * min;
        var withoutMinimum = Math.Max(F(L, minIndex-1), F(minIndex+1, R));

        return Math.Max(withMinimum, withoutMinimum);
    }

    // editorial, но мне понятно
    // TL
    public int LargestRectangleArea(int[] heights) {
        _heights = heights;
        return F(0, heights.Length-1);
    }
}