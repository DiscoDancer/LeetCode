public class Solution {
    // dynamic sliding window (не пройдет, потому что не выполняется то, что подстрока валидна если строка валидна)
    // stepik divide and conquer
    // привет перебор

    // too slow
    public int MaxSubArray(int[] nums) {
        int? max = null;
        for (int i = 0; i < nums.Length; i++) {
            var curSum = 0;
            for (int j = i; j < nums.Length; j++) {
                curSum += nums[j];
                if (!max.HasValue) {
                    max = curSum;
                }
                else {
                    max = Math.Max(max.Value, curSum);
                }
            }
        }

        return max.Value;
    }
}