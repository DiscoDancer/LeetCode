public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        var visited = new bool[rooms.Count()];
        visited[0] = true;

        var queue = new Queue<int>();
        queue.Enqueue(0);

        while (queue.Any()) {
            var index = queue.Dequeue();
            foreach (var child in rooms[index]) {
                if (!visited[child]) {
                    visited[child] = true;
                    queue.Enqueue(child);
                }
            }
        }

        return visited.All(x => x);
    }
}