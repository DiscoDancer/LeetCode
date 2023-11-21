public class Solution {
    // сработало, но непонятно, почему
    public int FindMinArrowShots(int[][] points) {
        var sortedIntervals = points.OrderBy(x => x[1]).ToArray();
        var k = sortedIntervals[0][1];

        var result = 1;

        for (int i = 1; i < sortedIntervals.Length; i++) {
            var cur = sortedIntervals[i];
            var curL = cur[0];
            var curR = cur[1];

            if (curL > k) {
                result++;
                k = curR;
            }
            // если они смежные, то переходим второй?
            // не, фигня, так потеряю транзитивность
            else if (curL <= k) {
                // k = curR;
            }
        }

        return result;
    }
}