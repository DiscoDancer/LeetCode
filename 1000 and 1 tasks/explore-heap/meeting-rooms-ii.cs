public class Solution {
    public class Room {
        public int Until {get; set;}
    }

    public int MinMeetingRooms(int[][] intervals) {
        var sorted = intervals.OrderBy(x => x[0]).ToArray();
        var total = 0;
        var free = 0;
        var rooms = new List<Room>();

        foreach (var interval in sorted) {
            var from = interval[0];
            var to = interval[1];

            var freeRoom = rooms.FirstOrDefault(r => r.Until <= from);
            if (freeRoom == null) {
                var newRoom = new Room {
                    Until = to,
                };
                rooms.Add(newRoom);
            }
            else {
                freeRoom.Until = to;
            }
        }

        return rooms.Count();
    }
}