public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        Array.Sort(nums1);
        Array.Sort(nums2);

        var result = new List<int>();

        var i = 0;
        var j = 0;

        while (i < nums1.Length && j < nums2.Length) {
            while (i < nums1.Length && j < nums2.Length && nums1[i] < nums2[j]) {
                i++;
            }
            while (i < nums1.Length && j < nums2.Length && nums2[j] < nums1[i]) {
                j++;
            }
            while (i < nums1.Length && j < nums2.Length && nums1[i] == nums2[j]) {
                if (!result.Any() || result.Last() != nums1[i])
                {
                    result.Add(nums1[i]);
                }
                i++;
                j++;
            }
        }

        return result.ToArray();
    }
}