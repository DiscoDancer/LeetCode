public class Solution {
    public int SingleNumber(int[] nums) {
        if (nums.Length == 1) {
            return nums.First();
        }

        var res = nums[0];
        for (int i = 1; i < nums.Length; i++) {
            res = res ^ nums[i];
        }

        return res;
    }
}