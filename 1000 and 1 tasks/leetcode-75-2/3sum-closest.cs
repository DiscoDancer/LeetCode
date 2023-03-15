public class Solution {
    private int FindDistance(int x, int y) {
        if (x > 0 && y > 0 || x < 0 && y < 0) {
            return Math.Abs(Math.Abs(x) - Math.Abs(y));
        }
        if (x == 0) {
            return Math.Abs(y);
        }
        if (y == 0) {
            return Math.Abs(x);
        }

        return Math.Abs(x) + Math.Abs(y);
    }

    // https://leetcode.com/problems/3sum-closest/editorial/
    public int ThreeSumClosest(int[] nums, int target) {
        nums = nums.OrderBy(x => x).ToArray();

        var minDistance = int.MaxValue;
        var minDistanceSum = 0;

        for (int i = 0; i < nums.Length; i++) {
            var l = i + 1;
            var r = nums.Length - 1;
            while (l < r) {
                var sum = nums[l] + nums[r] + nums[i];
                var distance = FindDistance(sum, target);
                if (distance < minDistance) {
                    minDistance = distance;
                    minDistanceSum = sum;
                }

                if (sum < target) {
                    l++;
                }
                else {
                    r--;
                }
            }
        }

        return minDistanceSum;
    }
}