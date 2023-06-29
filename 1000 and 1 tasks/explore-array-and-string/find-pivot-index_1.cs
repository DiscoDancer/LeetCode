public class Solution {
    public int PivotIndex(int[] nums) {
        var sum = nums.Sum();
        var n = nums.Length;

        var leftSum = 0;
        var rightSum = sum;

        for (int i = 0; i < n; i++) {
            rightSum -= nums[i];

            if (leftSum == rightSum) {
                return i;
            }

            leftSum += nums[i];

        }

        return -1;
    }
}