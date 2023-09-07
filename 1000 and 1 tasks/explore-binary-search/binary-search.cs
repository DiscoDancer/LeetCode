public class Solution {
    public int Search(int[] nums, int target) {
        var L = 0;
        var R = nums.Length - 1;

        while (L <= R) {
            var M = L + (R-L)/2;

            if (nums[M] == target) {
                return M;
            }
            if (nums[M] < target) {
                L = M + 1;
            }
            else {
                R = M - 1;
            }
        }

        return -1;
    }
}