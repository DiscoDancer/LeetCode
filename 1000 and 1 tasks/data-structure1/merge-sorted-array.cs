public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        var res = new int[m + n];

        var p1 = 0;
        var p2 = 0;

        var k = 0;
        // пока есть в обоих
        while (p1 < m && p2 < n) {
            if (nums1[p1] <= nums2[p2]) {
                res[k++] = nums1[p1++];
            } else {
                res[k++] = nums2[p2++];
            }
        }

        // остался либо в 1 либо во 2

        while (p1 < m) {
            res[k++] = nums1[p1++];
        }

        while (p2 < n) {
            res[k++] = nums2[p2++];
        }

        for (int i = 0; i < n + m; i++) {
            nums1[i] = res[i];
        }
    }
}