public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        var sorted = intervals.OrderBy(x => x[0]).ToArray();
        var minHeap = new PriorityQueue<int, int>();

        foreach (var interval in sorted) {
            var from = interval[0];
            var to = interval[1];

            if (minHeap.Count == 0 || minHeap.Peek() > from) {
                minHeap.Enqueue(to, to);
            }
            else {
                minHeap.Dequeue();
                minHeap.Enqueue(to, to);
            }
        }

        return minHeap.Count;
    }
}