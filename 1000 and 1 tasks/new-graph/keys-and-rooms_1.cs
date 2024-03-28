public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        var n = rooms.Count();
        var visited = new bool[n];
        var visitedCount = 1;

        var queue = new Queue<int>();
        queue.Enqueue(0);
        visited[0] = true;

        while (queue.Any()) {
            var x = queue.Dequeue();
            foreach (var y in rooms[x]) {
                if (!visited[y]) {
                    visitedCount++;
                    queue.Enqueue(y);
                    visited[y] = true;
                }
            }
        }

        return visitedCount == n;
    }
}