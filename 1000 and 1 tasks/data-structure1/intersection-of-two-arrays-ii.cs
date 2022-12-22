public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        const int MaxValue = 1001;
        var table1 = new int[MaxValue];
        var table2 = new int[MaxValue];

        foreach (var i in nums1) {
            table1[i]++;
        }
        foreach (var i in nums2) {
            table2[i]++;
        }

        var res = new List<int>();
        for (int i = 0; i < MaxValue; i++) {
            if (table1[i] > 0 && table2[i] > 0) {
                for (int j = 0; j < Math.Min(table1[i], table2[i]); j++) {
                    res.Add(i);
                }
            }
        }

        return res.ToArray();
    }
}