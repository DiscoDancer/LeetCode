public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        var visited = new bool[rooms.Count()];

        var queue = new Queue<int>();
        queue.Enqueue(0);

        while (queue.Any()) {
            var cur = queue.Dequeue();
            visited[cur] = true;

            foreach (var n in rooms.ElementAt(cur)) {
                if (!visited[n]) {
                    queue.Enqueue(n);
                }                
            }
        }

        return visited.All(x => x);
    }
}