import java.util.*;

class Solution {

    private int findLastLessThan(int[] nums, int target) {
        var l = 0;
        var r = nums.length - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;
            if (nums[m] < target && (m == nums.length - 1 || nums[m + 1] >= target)) {
                return m;
            } else if (nums[m] < target) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }

        return -1;
    }

    private int findFirstBiggerThan(int[] nums, int target) {
        var l = 0;
        var r = nums.length - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;
            if (nums[m] > target && (m == 0 || nums[m - 1] <= target)) {
                return m;
            } else if (nums[m] <= target) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }

        return -1;
    }

    public double findMedianSortedArrays(int[] nums1, int[] nums2) {
        var l = 0;
        var r = nums1.length - 1;
        while (l <= r) {
            var i1 = l + (r - l) / 2;
            var lessThanCount1 = 1 + findLastLessThan(nums1, nums1[i1]);
            var firstBiggerThanIndex1 = findFirstBiggerThan(nums1, nums1[i1]);
            var biggerThanCount1 = firstBiggerThanIndex1 == -1 ? 0 : nums1.length - firstBiggerThanIndex1;
            var equalCount1 = nums1.length - lessThanCount1 - biggerThanCount1;

            var lessThanCount2 = 1 + findLastLessThan(nums2, nums1[i1]);
            var firstBiggerThanIndex2 = findFirstBiggerThan(nums2, nums1[i1]);
            var biggerThanCount2 = firstBiggerThanIndex2 == -1 ? 0 : nums2.length - firstBiggerThanIndex2;
            var equalCount2 = nums2.length - lessThanCount2 - biggerThanCount2;

            var firstEqualIndex = lessThanCount2 + lessThanCount1;
            // -1 чтобы не считать самого себя
            var lastEqualIndex = firstEqualIndex + equalCount1 + equalCount2 - 1;

            var goLeft = false;

            if ((nums1.length + nums2.length) % 2 == 1) {
                var medianIndex = (nums1.length + nums2.length) / 2;
                if (firstEqualIndex <= medianIndex && medianIndex <= lastEqualIndex) {
                    return nums1[i1];
                }
                goLeft = medianIndex < firstEqualIndex;
            } else {
                var firstMedianIndex = (nums1.length + nums2.length) / 2 - 1;
                var secondMedianIndex = (nums1.length + nums2.length) / 2;
                var canCurrentBeFirstMedianIndex = firstEqualIndex <= firstMedianIndex && firstMedianIndex <= lastEqualIndex;
                var canCurrentBeSecondMedianIndex = firstEqualIndex <= secondMedianIndex && secondMedianIndex <= lastEqualIndex;
                if (canCurrentBeFirstMedianIndex && canCurrentBeSecondMedianIndex) {
                    return nums1[i1];
                }
                if (canCurrentBeFirstMedianIndex && !canCurrentBeSecondMedianIndex) {
                    var next1 = lessThanCount1 + equalCount1 < nums1.length ? nums1[lessThanCount1 + equalCount1] : Integer.MAX_VALUE;
                    var next2 = firstBiggerThanIndex2 == -1 ? Integer.MAX_VALUE : nums2[firstBiggerThanIndex2];
                    // берем минимальный из следующего
                    return (double) (nums1[i1] + (Math.min(next1, next2))) / 2.0;
                }
                goLeft = firstMedianIndex < firstEqualIndex;
            }

            if (goLeft) {
                r = i1 - 1;
            } else {
                l = i1 + 1;
            }
        }

        // not found
        return findMedianSortedArrays(nums2, nums1);
    }
}
