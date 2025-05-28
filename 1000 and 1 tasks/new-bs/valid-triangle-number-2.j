import java.util.*;

class Solution {

    private int findLastLessThanIndex(int[] nums, int x, int i0) {

        var l = i0;
        var r = nums.length - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;
            if (nums[m] < x && (m == nums.length - 1 || nums[m + 1] >= x)) {
                return m;
            } else if (nums[m] < x) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }

        return -1;
    }

    private int findFirstIndexBiggerThan(int[] nums, int x, int i0) {
        for (var i = i0; i < nums.length; i++) {
            if (nums[i] > x) {
                return i;
            }
        }

        return -1;
    }

    public int triangleNumber(int[] nums) {

        Arrays.sort(nums);  // Sorts the array in ascending order

        var result = 0;

        for (var i = 0; i < nums.length; i++) {
            for (var j = i + 1; j < nums.length; j++) {
                var a = nums[i];
                var b = nums[j];
                // нужно найти k range

                // condition 1: nums[i] + nums[j] > nums[k]
                // condition 1: nums[k] < nums[i] + nums[j]
                var lastLessOrEqualThanIndex = findLastLessThanIndex(nums, a+b, j+1);
                if (lastLessOrEqualThanIndex == -1) {
                    continue;
                }
                var condition1LeftIncluding = 0;
                var condition1RightIncluding = lastLessOrEqualThanIndex;


                // condition 2: nums[i] + nums[k] > nums[j]
                // condition 2: nums[k] > nums[j] - nums[i]
                var firstBiggerThanIndex2 = findFirstIndexBiggerThan(nums, b - a, j + 1);
                if (firstBiggerThanIndex2 == -1) {
                    continue;
                }
                var condition2LeftIncluding = firstBiggerThanIndex2;
                var condition2RightIncluding = nums.length - 1;

                // condition 3: nums[j] + nums[k] > nums[i]
                // condition 3: nums[k] > nums[i] - nums[j]

                var firstBiggerThanIndex3 = findFirstIndexBiggerThan(nums, a - b, j + 1);
                if (firstBiggerThanIndex3 == -1) {
                    continue;
                }
                var condition3LeftIncluding = firstBiggerThanIndex3;
                var condition3RightIncluding = nums.length - 1;


                // merge intervals
                var left = Math.max(condition1LeftIncluding, Math.max(condition2LeftIncluding, condition3LeftIncluding));
                var right = Math.min(condition1RightIncluding, Math.min(condition2RightIncluding, condition3RightIncluding));

                var count = right - left + 1;

                if (count > 0) {
                    result += count;
                }
            }
        }

        return result;
    }
}
