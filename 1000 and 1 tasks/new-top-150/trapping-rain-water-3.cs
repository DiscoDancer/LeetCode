// оптимизировал editorial сам
public class Solution {
    public int Trap(int[] height) {
        int ans = 0;
        int size = height.Length;

        var rightMaxIncluding = new int[size];
        var leftMaxIncluding = new int[size];
        rightMaxIncluding[size-1] = height[size-1];
        leftMaxIncluding[0] = height[0];
        for (int i = size-2; i >= 0; i--) {
            rightMaxIncluding[i] = Math.Max(height[i], rightMaxIncluding[i+1]);
        }
         for (int i = 1; i < size; i++) {
            leftMaxIncluding[i] = Math.Max(height[i], leftMaxIncluding[i-1]);
         }

        for (int i = 1; i < size - 1; i++) {
            var left_max = leftMaxIncluding[i];
            var right_max = rightMaxIncluding[i];
            ans += Math.Min(left_max, right_max) - height[i];
        }
        return ans;
    }
}