public class Solution {
    public bool CanAttendMeetings(int[][] intervals) {
        var list = new List<(int x, int y)>();
        foreach (var interval in intervals) {
            list.Add((interval[0], interval[1]));
        }

        for (int i = 0; i < list.Count(); i++) {
            for (int j = 0; j < list.Count(); j++) {
                if (i == j) {
                    continue;
                }
                
                if (list[j].x == list[i].x && list[j].y == list[i].y) {
                    return false;
                }

                if (list[j].x <  list[i].x && list[i].x < list[j].y || list[j].x < list[i].y && list[i].y < list[j].y ) {
                    return false;
                }
            }
        }

        return true;
    }
}