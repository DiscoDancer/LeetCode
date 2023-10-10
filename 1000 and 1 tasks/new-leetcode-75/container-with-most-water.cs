public class Solution {
    // dp
    // 2nd 1st max (no working)
    // 2 pointers ссудя из названия
    public int MaxArea(int[] height) {
        var max = 0;

        for (int i = 0; i < height.Length; i++) {
            for (int j = i + 1; j < height.Length; j++) {
                max = Math.Max(max, Math.Min(height[i], height[j]) * (j - i));
            }
        }

        return max;
    }
}