public class Solution {
    /*
        Roadmap:
        - array table
        - dictionary table
    */
    public int[] Intersect(int[] nums1, int[] nums2) {
        var table1 = new Dictionary<int, int>();
        foreach (var i in nums1) {
            if (!table1.ContainsKey(i)) {
                table1[i] = 0;
            }
            table1[i]++;
        }

        var res = new List<int>();
        foreach (var i in nums2) {
            if (table1.ContainsKey(i) && table1[i] > 0) {
                res.Add(i);
                table1[i]--;
            }
        }

        return res.ToArray();
    }
}