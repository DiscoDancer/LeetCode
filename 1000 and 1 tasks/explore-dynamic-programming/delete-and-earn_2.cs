public class Solution {
    // editorial
    public int DeleteAndEarn(int[] nums) {
        var table = new Dictionary<int, int>();
        foreach (var n in nums) {
            if (!table.ContainsKey(n)) {
                table[n] = 0;
            }
            table[n] += n;
        }

        var prevPrev = 0;
        var prev = table.ContainsKey(1) ? table[1] : 0;
        var max = nums.Max();

        for (int i = 2; i <= max; i++) {
            var cur = Math.Max(prev, prevPrev + (table.ContainsKey(i) ? table[i] : 0));
            prevPrev = prev;
            prev = cur;
        }

        return prev;
    }
}