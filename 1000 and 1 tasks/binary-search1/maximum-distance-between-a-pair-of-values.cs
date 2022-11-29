public class Solution {
    public int MaxDistance(int[] nums1, int[] nums2) {
        var max = 0;
        
        for (int i = 0; i < nums1.Length; i++) {
            for (int j = i + 1; j < nums2.Length; j++) {
                if (nums1[i] <= nums2[j]) {
                    max = Math.Max(max, j - i);
                }
            }
        }
        
        return max;
    }
}