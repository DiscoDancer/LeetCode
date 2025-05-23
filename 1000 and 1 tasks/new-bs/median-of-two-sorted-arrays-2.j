import java.util.*;

class Solution {

    private int FindLastLessThanIndex(int[] arr, int x) {
        var l = 0;
        var r = arr.length - 1;

        while (l <= r) {
            var m = l + (r - l) / 2;
            // if m is the last element or next is bigger
            if (arr[m] < x && (m == arr.length - 1 || arr[m + 1] > x)) {
                return m;
            }
            if (arr[m] < x) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }

        return -1;
    }

    public double findMedianSortedArrays(int[] nums1, int[] nums2) {
        // 1 median
        if ((nums1.length + nums2.length) % 2 == 1) {
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

                var medianIndex = (nums1.length + nums2.length) / 2;
                var l = lessThanCount2 + lessThanCount1;
                var r = l + equalCount1 + equalCount2 - 1;
                if (l <= medianIndex && medianIndex <= r) {
                    return nums1[i1];
                }
            }

            // not found
            return findMedianSortedArrays(nums2, nums1);

        }
        // 2 median
        else if ((nums1.length + nums2.length) % 2 == 0) {
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

                for (var x: nums2) {
                    if (x < nums1[i1]) {
                        lessThanCount2++;
                    } else if (x == nums1[i1]) {
                        equalCount2++;
                    }
                }

                var firstMedianIndex = (nums1.length + nums2.length) / 2 - 1;
                var secondMedianIndex = (nums1.length + nums2.length) / 2;
                var l = lessThanCount2 + lessThanCount1;
                // -1 чтобы не считать самого себя
                var r = l + equalCount1 + equalCount2 - 1;
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
            // not found
            return findMedianSortedArrays(nums2, nums1);
        }

        return -1;
    }
}
