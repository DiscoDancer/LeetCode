public class Solution {
    public IList<IList<int>> FindDifference(int[] nums1, int[] nums2) {
        var hs1 = new HashSet<int>();
        foreach (var n in nums1) {
            hs1.Add(n);
        }

        var hs2 = new HashSet<int>();
        foreach (var n in nums2) {
            hs2.Add(n);
        }



        var list1 = new List<int>();
        var list2 = new List<int>();

        foreach (var n in hs1) {
            if (!hs2.Contains(n)) {
                list1.Add(n);
            }
        }


        foreach (var n in hs2) {
            if (!hs1.Contains(n)) {
                list2.Add(n);
            }
        }

        return new List<IList<int>>() {list1, list2};
    }
}