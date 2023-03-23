public class Solution {

    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        // copy nums1 to the end
        var k = m + n - 1;
        for (int i = m - 1; i >= 0; i--) {
            nums1[k--] = nums1[i];
        }

        var p1 = k + 1;
        var p2 = 0;
        k = 0;

        while (p1 < nums1.Length && p2 < n) {
            if (nums1[p1] <= nums2[p2]) {
                nums1[k++] = nums1[p1++];
            } else {
                nums1[k++] = nums2[p2++];
            }
        }

        // остался либо в 1 либо во 2

        while (p1 < nums1.Length) {
            nums1[k++] = nums1[p1++];
        }

        while (p2 < n) {
            nums1[k++] = nums2[p2++];
        }

    }
}