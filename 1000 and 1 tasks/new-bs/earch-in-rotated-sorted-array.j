import java.util.Arrays;
import java.util.Comparator;

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

    public int search(int[] nums, int target) {
        var strangeIndex = findStrangeIndex(nums);

        // l и r - вирутальные границы
        // чтобы перейти в реальные, надо сделать (m+strangeIndex + 1) % nums.length
        var l = 0;
        var r = nums.length - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;
            var mVal = nums[(m+strangeIndex + 1) % nums.length];
            if (mVal == target) {
                return (m+strangeIndex + 1) % nums.length;
            }
            else if (mVal > target) {
                r = m - 1;
            }
            else {
                l = m + 1;
            }
        }

        return -1;
    }
}
