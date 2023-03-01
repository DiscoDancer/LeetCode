public class Solution {
    // https://leetcode.com/problems/meeting-rooms/editorial/

    /*
        Чтобы лучше понять:
        - 1-8 и 1-2
        - 1-2 и 1-8
    */
    public bool CanAttendMeetings(int[][] intervals) {
        var sorted = intervals.OrderBy(x => x[0]).ToArray();

        for (int i = 0; i < sorted.Length - 1; i++) {
            if (sorted[i][1] > sorted[i+1][0]) {
                return false;
            }
        }

        return true;
    }
}