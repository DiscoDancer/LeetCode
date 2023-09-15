public class Solution {
    // проходит, но не то
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        var nums = new int[nums1.Length + nums2.Length];

        var i = 0;
        var j = 0;
        var k = 0;

        while (i < nums1.Length && j < nums2.Length) {
            if (i < nums1.Length && j < nums2.Length && nums1[i] <= nums2[j]) {
                nums[k++] = nums1[i++];
            }
            else if (i < nums1.Length && j < nums2.Length && nums1[i] > nums2[j]) {
                nums[k++] = nums2[j++];
            }
        }

        while (i < nums1.Length) {
            nums[k++] = nums1[i++];
        }

        while (j < nums2.Length) {
            nums[k++] = nums2[j++];
        }

        if (nums.Length % 2 == 1) {
            return nums[nums.Length/2];
        }

        double result = 0;
        result += nums[nums.Length/2];
        result += nums[nums.Length/2 - 1];

        return result / 2;
    }
}