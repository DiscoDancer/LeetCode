public class Solution {
    // копипаста соседней задачи search-in-rotated-sorted-array
    public int FindShift(int[] nums) {
        var L = 0;
        var R = nums.Length - 1;

        while (L <= R) {
            var M = L + (R-L)/2;

            if (M == nums.Length - 1 || nums[M] > nums[M+1]) {
                return M;
            }
            if (nums[M] < nums[L]) {
                R = M - 1;
            }
            else {
                L = M + 1;
            }
        }

        return -1;
    }

    public int FindMin(int[] nums) {
        return nums[(FindShift(nums) + 1) % nums.Length];
    }
}