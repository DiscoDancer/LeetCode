public class Solution {
    /*
        Roadmap:
        - array table
        - dictionary table
    */
    public int[] Intersect(int[] nums1, int[] nums2) {
        var table1 = new Dictionary<int, int>();
        var table2 = new Dictionary<int, int>();

        foreach (var i in nums1) {
            if (!table1.ContainsKey(i)) {
                table1[i] = 0;
            }
            table1[i]++;
        }
        foreach (var i in nums2) {
            if (!table2.ContainsKey(i)) {
                table2[i] = 0;
            }
            table2[i]++;
        }

        var res = new List<int>();
        foreach (var key in table1.Keys) {
            if (table2.ContainsKey(key)) {
                for (int j = 0; j < Math.Min(table1[key], table2[key]); j++) {
                    res.Add(key);
                }
            }
        }

        return res.ToArray();
    }
}