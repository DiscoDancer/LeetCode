public class Solution {
    // editorial
    public int FindLength(int[] nums1, int[] nums2) {
        var max = 0;

        var table = new int[nums1.Length + 1, nums2.Length + 1];

        for (int i = nums1.Length - 1; i >=0; i--) {
            for (int j = nums2.Length - 1; j >= 0; j--) {
                if (nums1[i] == nums2[j]) {
                    table[i,j] = table[i+1,j+1] + 1;
                }

                max = Math.Max(max, table[i,j]);
            }
        }

        return max;
    }
}