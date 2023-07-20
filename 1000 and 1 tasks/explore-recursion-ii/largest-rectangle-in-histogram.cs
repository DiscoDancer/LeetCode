public class Solution {
    // monothoic stack
    // 2 pointers or 2 point dp

    // TL
    public int LargestRectangleArea(int[] heights) {
        var max = 0;

        for (int i = 0; i < heights.Length; i++) {
            for (int height = heights[i]; height > 0; height--) {
                var sum = height;
                var j = i+1;
                while (j < heights.Length && heights[j] >= height) {
                    sum += height;
                    j++;
                }

                max = Math.Max(max, sum);
            }
        }

        return max;
    }
}