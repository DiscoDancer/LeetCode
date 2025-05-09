import java.util.Arrays;
import java.util.Comparator;

// see find-minimum-in-rotated-sorted-array

class Solution {

    private int[] nums;

    private int findStrangeIndex(int l, int r) {
        while (l <= r) {
            var m = l + (r - l) / 2;

            // criterion: with both neighbors & last of previous duplicates
            if (m > 0 && m < nums.length - 1 && nums[m] >= nums[m - 1] && nums[m] > nums[m + 1]) {
                return m;
            }
            // criterion: first & next is smaller
            if (m == 0 && m < nums.length - 1 && nums[m] > nums[m + 1]) {
                return m;
            }

            // m = 2 и непонятно, где искать. Будем искать везде!
            // 10 1 10 10 10
            // 10 10 10 1 10
            var isMInLeftHalf = nums[l] <= nums[m];
            var isMInRightHalf = nums[m] <= nums[r];
            if (isMInRightHalf && isMInLeftHalf) {
                // m is already checked
                // could cache, but it is not needed
                // it looks more like divide and conquer than dynamic programming
                return Math.max(findStrangeIndex(l,m-1), findStrangeIndex(m+1,r));
            }
            if (isMInLeftHalf) {
                l = m + 1;

            } else {
                r = m - 1;
            }
        }

        return -1;
    }

    public int findMin(int[] nums) {
        this.nums = nums;

        return nums[(findStrangeIndex(0, nums.length - 1) +1) % nums.length];
    }
}
