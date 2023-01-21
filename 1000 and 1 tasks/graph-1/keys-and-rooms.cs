public class Solution {
    public bool CanVisitAllRooms(IList<IList<int>> rooms) {
        var visited = new bool[rooms.Count()];

        var queue = new Queue<List<int>>();
        queue.Enqueue(new List<int>() {0});

        while (queue.Any()) {
            var cur = queue.Dequeue();
            var last = cur.Last();
            visited[last] = true;

            foreach (var n in rooms.ElementAt(last)) {
                if (visited[n]) {
                    continue;
                }

                var copy = new List<int>();
                copy.AddRange(cur);
                copy.Add(n);
                queue.Enqueue(copy);
            }
        }

        return visited.All(x => x);
    }
}