public class Solution {

    // TL

    public int LargestRectangleArea(int[] heights) {
        var lessFromLeft = new int[heights.Length];
        var lessFromRight = new int[heights.Length];

        lessFromLeft[0] = -1;
        for (int i = 1; i < heights.Length; i++) {
            var p = i-1;
            while (p >= 0 && heights[p] >= heights[i])
            {
                p--;
            }
            lessFromLeft[i] = p;
        }


        for (int i = 0; i < heights.Length-1; i++) {
            var p = i+1;
            while (p < heights.Length && heights[p] >= heights[i]) {
                p++;
            }
            lessFromRight[i] = p;
        }
        lessFromRight[heights.Length - 1] = heights.Length;

        var max = 0;
        for (int i = 0; i < heights.Length; i++)
        {
            max = Math.Max(max, heights[i]);
            max = Math.Max(max, heights[i] * (lessFromRight[i] - lessFromLeft[i] - 1));
        }

        return max;
    }
}