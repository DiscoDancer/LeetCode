public class Solution {
    /*
        Roadmap:
        - array table
        - dictionary table
    */
    public int[] Intersect(int[] nums1, int[] nums2) {
        Array.Sort(nums1);
        Array.Sort(nums2);

        var p1 = 0;
        var p2 = 0;

        var res = new List<int>();
        while (p1 < nums1.Length && p2 < nums2.Length) {
            while (p1 < nums1.Length && p2 < nums2.Length && nums1[p1] < nums2[p2]) {
                p1++;
            }
            while (p1 < nums1.Length && p2 < nums2.Length && nums2[p2] < nums1[p1]) {
                p2++;
            }
            while (p1 < nums1.Length && p2 < nums2.Length && nums2[p2] == nums1[p1] ) {
                res.Add(nums2[p2]);
                p1++;
                p2++;
            }
        }

        return res.ToArray();
    }
}