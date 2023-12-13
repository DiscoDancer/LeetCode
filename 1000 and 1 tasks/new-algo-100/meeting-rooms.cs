public class Solution {
    public bool CanAttendMeetings(int[][] intervals) {
        if (intervals.Length <= 1) {
            return true;
        }

        var sorted = intervals.OrderBy(x => x[0]).ToArray();
        var prev = sorted[0];

        for (int i = 1; i < sorted.Length; i++) {
            var cur = sorted[i];

            if (prev[1] > cur[0]) {
                return false;
            }

            prev = cur;
        }

        return true;
    }
}