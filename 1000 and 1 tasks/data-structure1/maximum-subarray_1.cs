public class Solution {
    // dynamic sliding window (не пройдет, потому что не выполняется то, что подстрока валидна если строка валидна)
    // stepik divide and conquer
    // привет перебор
    public int MaxSubArray(int[] nums) {
        int max = nums[0];
        for (int i = 0; i < nums.Length; i++) {
            var curSum = 0;
            for (int j = i; j < nums.Length; j++) {
                curSum += nums[j];
                max = Math.Max(max, curSum);
            }
        }

        return max;
    }
}