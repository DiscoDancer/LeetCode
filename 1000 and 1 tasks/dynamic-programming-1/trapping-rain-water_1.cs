public class Solution {
    public int Trap(int[] height) {
        var res = 0;

        https://leetcode.com/problems/trapping-rain-water/solutions/127551/trapping-rain-water/?envType=study-plan&id=dynamic-programming-i&orderBy=most_votes
        // крайние там не интересны, там не может быть воды
        for (int i = 1; i < height.Length - 1; i++) {
            var leftMax = 0;
            for (var il = i; il >= 0; il--) {
                leftMax = Math.Max(leftMax, height[il]);
            }

            var rightMax = 0;
            for (var ir = i; ir < height.Length; ir++) {
                rightMax = Math.Max(rightMax, height[ir]);
            }

            res += Math.Min(leftMax, rightMax) - height[i];
        }

        return res;
    }
}