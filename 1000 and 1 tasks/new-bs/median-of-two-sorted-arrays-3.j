import java.util.*;

class Solution {

    public double findMedianSortedArrays(int[] nums1, int[] nums2) {
        for (var i1 = 0; i1 < nums1.length; i1++) {
            var lessThanCount1 = 0;
            var equalCount1 = 0;
            for (var x: nums1) {
                if (x < nums1[i1]) {
                    lessThanCount1++;
                } else if (x == nums1[i1]) {
                    equalCount1++;
                }
            }

            var lessThanCount2 = 0;
            var equalCount2 = 0;
            for (var x : nums2) {
                if (x < nums1[i1]) {
                    lessThanCount2++;
                } else if (x == nums1[i1]) {
                    equalCount2++;
                }
            }

            var l = lessThanCount2 + lessThanCount1;
            // -1 чтобы не считать самого себя
            var r = l + equalCount1 + equalCount2 - 1;

            if ((nums1.length + nums2.length) % 2 == 1) {
                var medianIndex = (nums1.length + nums2.length) / 2;
                if (l <= medianIndex && medianIndex <= r) {
                    return nums1[i1];
                }
            }
            else {
                var firstMedianIndex = (nums1.length + nums2.length) / 2 - 1;
                var secondMedianIndex = (nums1.length + nums2.length) / 2;
                var canCurrentBeFirstMedianIndex = l <= firstMedianIndex && firstMedianIndex <= r;
                var canCurrentBeSecondMedianIndex = l <= secondMedianIndex && secondMedianIndex <= r;
                if (canCurrentBeFirstMedianIndex && canCurrentBeSecondMedianIndex) {
                    return nums1[i1];
                }
                if (canCurrentBeFirstMedianIndex && !canCurrentBeSecondMedianIndex) {
                    var next1 = lessThanCount1 + equalCount1 < nums1.length ? nums1[lessThanCount1 + equalCount1] : Integer.MAX_VALUE;
                    var next2 = Integer.MAX_VALUE;
                    for (var k : nums2) {
                        if (k > nums1[i1]) {
                            next2 = k;
                            break;
                        }
                    }
                    // берем минимальный из следующего
                    return (double) (nums1[i1] + (Math.min(next1, next2))) / 2.0;
                }
            }
        }

        // not found
        return findMedianSortedArrays(nums2, nums1);
    }
}
