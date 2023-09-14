public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        var table = new Dictionary<int, (int x, int y)>();

        foreach (var n in nums1) {
            if (!table.ContainsKey(n)) {
                table[n] = (1,0);
            }
            else {
                table[n] = (table[n].x + 1, 0);
            }
        }

        var result = new List<int>();

        foreach (var n in nums2) {
            if (table.ContainsKey(n)) {
                table[n] = (table[n].x, table[n].y + 1);
            }
        }

        foreach (var n in table.Keys) {
            for (int i = 0; i < Math.Min(table[n].x, table[n].y); i++) {
                result.Add(n);
            }
        }

        return result.ToArray();
    }
}