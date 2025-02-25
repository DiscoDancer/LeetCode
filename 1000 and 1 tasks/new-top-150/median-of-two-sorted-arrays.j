import java.util.Arrays;

// naive, works

class Solution {

    public double findMedianSortedArrays(int[] nums1, int[] nums2) {

        var arr = new int[nums1.length + nums2.length];
        var i = 0;
        for (var n : nums1) {
            arr[i++] = n;
        }
        for (var n : nums2) {
            arr[i++] = n;
        }

        Arrays.sort(arr);

        if (i % 2 == 0) {
            return (arr[i / 2 - 1] + arr[i / 2]) / 2.0;
        } else {
            return arr[i / 2];
        }
    }
}