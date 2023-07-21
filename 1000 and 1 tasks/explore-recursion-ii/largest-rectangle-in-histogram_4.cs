public class Solution {

    // TL

    public int LargestRectangleArea(int[] heights) {
        var lessFromLeft = new int[heights.Length];
        var lessFromRight = new int[heights.Length];

        for (int i = 1; i < heights.Length; i++) {
            lessFromLeft[i] = i;
            var p = i-1;
            while (p >= 0 && heights[p] >= heights[i])
            {
                lessFromLeft[i] = p;
                p--;
            }
        }
        lessFromLeft[0] = 0;

        for (int i = 0; i < heights.Length-1; i++) {
            lessFromRight[i] = i;
            var p = i+1;
            while (p < heights.Length && heights[p] >= heights[i]) {
                lessFromRight[i] = p;
                p++;
            }
        }
        lessFromRight[heights.Length - 1] = heights.Length - 1;

        var max = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            max = Math.Max(max, heights[i] * (lessFromRight[i] - lessFromLeft[i] + 1));
        }

        return max;
    }
}