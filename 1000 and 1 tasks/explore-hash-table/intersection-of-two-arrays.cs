public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        var hs = new HashSet<int>();
        foreach (var n in nums1) {
            hs.Add(n);
        }

        var result = new HashSet<int>();
        foreach (var n in nums2) {
            if (hs.Contains(n)) {
                result.Add(n);
            }
        }

        return result.ToArray();
    }
}