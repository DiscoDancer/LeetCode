import java.util.Arrays;
import java.util.Comparator;

// see find-minimum-in-rotated-sorted-array

class Solution {

    private int findStrangeIndex(int[] nums) {
        var l = 0;
        var r = nums.length - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;

            // criterion for the peak element with both neighbors
            if (m > 0 && m < nums.length - 1 && nums[m] > nums[m - 1] && nums[m] > nums[m + 1]) {
                return m;
            }
            // 2 1, where m = 2
            if (m == 0 && m < nums.length - 1 && nums[m] > nums[m + 1]) {
                return m;
            }

            var isMInLeftHalf = nums[l] <= nums[m];
            if (isMInLeftHalf) {
                l = m + 1;

            } else {
                r = m - 1;
            }
        }

        return -1;
    }

    public int findMin(int[] nums) {
        return nums[(findStrangeIndex(nums) +1) % nums.length];
    }
}
