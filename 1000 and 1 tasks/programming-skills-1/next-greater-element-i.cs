public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        var res = new int[nums1.Length];

        for (int i = 0; i < res.Length; i++) {
            int j = 0;
            while (nums2[j] != nums1[i]) {
                j++;
            }
            while(j < nums2.Length && nums2[j] <= nums1[i]) {
                j++;
            }
            res[i] = j < nums2.Length ? nums2[j] : -1;
        }

        return res;
    }
}