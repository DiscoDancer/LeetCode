public class Solution {
    public int LargestAltitude(int[] gain) {
        var max = 0;
        var cur = 0;

        foreach (var n in gain) {
            cur += n;
            max = Math.Max(cur, max);
        }

        return max;
    }
}