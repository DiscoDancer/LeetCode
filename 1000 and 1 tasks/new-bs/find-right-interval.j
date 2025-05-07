class Solution {

    // naive, works

    public int[] findRightInterval(int[][] intervals) {
        var n = intervals.length;
        var result = new int[n];

        for (var i = 0; i < n; i++) {
            var minStart = Integer.MAX_VALUE;
            var minStartIndex = -1;
            for (var j = 0; j < n; j++) {
//                if (i == j) {
//                    continue;
//                }
                if (intervals[j][0] >= intervals[i][1] && intervals[j][0] < minStart) {
                    minStart = intervals[j][0];
                    minStartIndex = j;
                }
            }
            if (minStart == Integer.MAX_VALUE) {
                result[i] = -1;
            } else {
                result[i] = minStartIndex;
            }
        }

        return result;
    }
}
