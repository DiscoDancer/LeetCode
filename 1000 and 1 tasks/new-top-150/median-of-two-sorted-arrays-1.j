import java.util.Arrays;

class Solution {

    public int[] merge(int[] nums1, int[] nums2) {
        var arr = new int[nums1.length + nums2.length];
        var i = 0;
        
        var j1 = 0;
        var j2 = 0;
        
        while (j1 < nums1.length && j2 < nums2.length) {
            if (nums1[j1] < nums2[j2]) {
                arr[i++] = nums1[j1++];
            } else {
                arr[i++] = nums2[j2++];
            }
        }
        while (j1 < nums1.length) {
            arr[i++] = nums1[j1++];
        }
        while (j2 < nums2.length) {
            arr[i++] = nums2[j2++];
        }
        
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