import java.util.Arrays;

class Solution {

    public int[] merge(int[] nums1, int[] nums2) {
        var arr = new int[nums1.length + nums2.length];
        var i = 0;
        for (var n : nums1) {
            arr[i++] = n;
        }
        for (var n : nums2) {
            arr[i++] = n;
        }
        Arrays.sort(arr);
        return arr;
    }

    public double findMedianSortedArrays(int[] nums1, int[] nums2) {

        var arr = merge(nums1, nums2);

        if (arr.length % 2 == 0) {
            return (arr[arr.length / 2 - 1] + arr[arr.length / 2]) / 2.0;
        } else {
            return arr[arr.length / 2];
        }
    }
}