public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        var table1 = new int[1001];

        foreach (var n in nums1) {
            table1[n]++;
        }
        var result = new List<int>();
        foreach (var n in nums2) {
            if (table1[n] > 0) {
                result.Add(n);
                table1[n]--;
            }
        }

        return result.ToArray();
    }
}