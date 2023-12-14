public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        var sorted = intervals.OrderBy(x => x[0]).ToArray();
        var rooms = new PriorityQueue<int, int>() {};

        foreach (var interval in sorted) {
            var hasRoom = rooms.Count > 0 && rooms.Peek() <= interval[0];
            if (hasRoom) {
                rooms.Dequeue();
            }
            rooms.Enqueue(interval[1], interval[1]);
        }

        return rooms.Count;
    }
}