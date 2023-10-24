public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        var isVisited = new bool[1001];
        var queue = new Queue<int>();
        queue.Enqueue(0);
        isVisited[0] = true;
        var visitedCount = 1;

        while (queue.Any()) {
            var cur = queue.Dequeue();
            foreach (var r in rooms[cur]) {
                if (!isVisited[r]) {
                    queue.Enqueue(r);
                    visitedCount++;
                    isVisited[r] = true;
                }
            }
        }

        return visitedCount == rooms.Count();
    }
}