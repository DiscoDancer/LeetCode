public class Solution {
    // [1,7,3,6,5,6]
    // [0,1,8,11,17,22]

    public int PivotIndex(int[] nums) {
        // [1,7,3,6,5,6]
        // [0,1,8,11,17,22]
        var sums = new int[nums.Length];
        for (int i = 1; i < nums.Length; i++) {
            sums[i] = sums[i-1] + nums[i-1];
        }

        for (int i = 0; i < nums.Length; i++) {
            var num = nums[i];
            var left = sums[i];
            int right = 0;
            if (i != nums.Length - 1) {
                right = sums.Last() + nums.Last() - nums[i] - sums[i];
            }
            if (left == right) {
                return i;
            }
        }

        return -1;
    }
}