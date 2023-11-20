public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        var sortedIntervals = intervals.OrderBy(x => x[1]).ToArray();
        var ans = 0;
        var k = int.MinValue;

        for (int i = 0; i < sortedIntervals.Length; i++) {
            int x = sortedIntervals[i][0];
            int y = sortedIntervals[i][1];

            if (x >= k) {
                // Case 1
                k = y;
            } else {
                // Case 2
                ans++;
            }
        }


        return ans;
    }
}