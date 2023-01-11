public class Solution {
    // from comments
    public int Trap(int[] height) {
        var left = 0;
        var right = height.Length - 1;
        var leftMax = 0;
        var rightMax = 0;
        var result = 0;

        while (left < right) {
            leftMax = Math.Max(leftMax, height[left]);
            rightMax = Math.Max(rightMax, height[right]);

            if (leftMax < rightMax) {
                result += Math.Max(0, leftMax-height[left]);
                left++;
            }
            else {
                result += Math.Max(0, rightMax-height[right]);
                right--;
            }
        }

        return result;
    }
}