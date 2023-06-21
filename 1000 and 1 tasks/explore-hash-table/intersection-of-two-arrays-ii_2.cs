public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        if (nums1.Length > nums2.Length) {
            return Intersect(nums2, nums1);
        }

        Array.Sort(nums1);
        Array.Sort(nums2);

        var i = 0;
        var j = 0;
        var k = 0;

        while (i < nums1.Length && j < nums2.Length) {
            if (nums1[i] < nums2[j]) {
                i++;
            }
            else if (nums1[i] > nums2[j]) {
                j++;
            }
            else {
                j++;
                nums1[k++] = nums1[i++];
            }
        }

        return nums1.Take(k).ToArray();
    }
}