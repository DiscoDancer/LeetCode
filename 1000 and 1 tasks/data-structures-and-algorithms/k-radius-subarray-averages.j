import java.util.Arrays;

class Solution {
    public int[] getAverages(int[] nums, int k) {
        var prefixSum = new long[nums.length];
        prefixSum[0] = nums[0];
        for (var i = 1; i < nums.length; i++) {
            prefixSum[i] = prefixSum[i-1] + nums[i];
        }

        var result = new int[nums.length];

        for (var i = 0; i < nums.length; i++) {
            var leftCount = i;
            var rightCount = nums.length - i - 1;
            if (k == 0) {
                result[i] = nums[i];
            }
            else if (leftCount < k || rightCount < k) {
                result[i] = -1;
            }
            else {
                var leftSum = prefixSum[i-1] - ( (i-k - 1) >= 0 ? prefixSum[i-k - 1] : 0);
                var rightSum = prefixSum[i + k] - prefixSum[i];
                long totalSum = leftSum + rightSum + nums[i];
                result[i] = (int)(totalSum / (k*2+1));
            }
        }

        return result;
    }
}