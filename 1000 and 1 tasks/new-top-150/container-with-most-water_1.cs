public class Solution {
    // нужно смыкаться к точке, но впрос как

    public int MaxArea(int[] height) {
        var max = 0;

        var l = 0;
        var r = height.Length - 1;

        while (l < r) {
            max = Math.Max(max, (r-l)*(Math.Min(height[l], height[r]))    );
            // это довольно очевидно
            if (height[l] < height[r]) {
                l++;
            }
            // и это тоже
            else if (height[l] > height[r]) {
                r--;
            }
            // но это нет
            else {
                l++;
                r--;
            }
        }

        return max;
    }
}