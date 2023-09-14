public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        var hs1 = new HashSet<int>();
        foreach (var n in nums1) {
            hs1.Add(n);
        }

        var hs2 = new HashSet<int>();
        foreach (var n in nums2) {
            hs2.Add(n);
        }

        var result = new List<int>();
        foreach (var n in hs1) {
            if (!hs2.Add(n)) {
                result.Add(n);
            }
        }

        return result.ToArray();
    }
}