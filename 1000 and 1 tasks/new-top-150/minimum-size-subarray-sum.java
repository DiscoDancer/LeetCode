class Solution {
    // sums left / right for each element
    // sub array not allows skipping !!!
    public int minSubArrayLen(int target, int[] nums) {

        var result = Integer.MAX_VALUE;

        for (var i = 0; i < nums.length; i++) {
            var sum = nums[i];
            var count = 0;
            var j = i + 1;
            while (j < nums.length && sum < target) {
                sum += nums[j];
                j++;
                count++;
            }
            if (sum >= target) {
                result = Math.min(result, count + 1);
            }
        }
        
        return result == Integer.MAX_VALUE ? 0 : result;
    }
}