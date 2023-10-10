public class Solution {
    public int MaxArea(int[] height) {
        var l = 0;
        var r = height.Length - 1;

        var max = 0;
        while (l < r) {
            while (l < r && height[l] < height[r]) {
                var cur = Math.Min(height[l], height[r]) * (r - l);
                max = Math.Max(max, cur);
                l++;
            }

            while (r > l && height[l] > height[r]) {
                var cur = Math.Min(height[l], height[r]) * (r - l);
                max = Math.Max(max, cur);
                r--;
            }

            // идем дальше, чтобы не застрять
            if (l < r && height[l] == height[r]) {
                var cur = Math.Min(height[l], height[r]) * (r - l);
                max = Math.Max(max, cur);
                l++;
            }
        }

        return max;
    }
}