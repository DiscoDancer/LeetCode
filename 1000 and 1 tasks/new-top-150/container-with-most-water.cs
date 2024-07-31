public class Solution {
    // TL
    public int MaxArea(int[] height) {
        var max = 0;
        for (int l = 0; l < height.Length; l++) {
            for (int r = l+1; r < height.Length; r++) {
                max = Math.Max(max, (r-l)*(Math.Min(height[l], height[r]))    );
            }
        }

        return max;
    }
}