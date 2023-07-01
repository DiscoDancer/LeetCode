public class Solution {
    // editorial
    public int MinSubArrayLen(int target, int[] nums) {
        var result = int.MaxValue;

        var left = 0;
        long sum = 0;
        for (var right = 0; right < nums.Length; right++) {
            sum += nums[right];

            while (sum >= target) {
                result = Math.Min(result, right - left + 1);
                sum -= nums[left++];
            }
        }

        return result == int.MaxValue ? 0 : result;
    }
}