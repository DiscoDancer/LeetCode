public class Solution {
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        var n = graph.Length;

        var queue = new Queue<List<int>>();
        queue.Enqueue(new List<int>() {0});

        var result = new List<IList<int>>();

        while (queue.Any()) {
            var cur = queue.Dequeue();

            if (cur.Last() == n-1) {
                result.Add(cur);
            }
            else {
                foreach (var neighbour in graph[cur.Last()]) {
                    if (!cur.Contains(neighbour)) {
                        var copy = cur.ToList();
                        copy.Add(neighbour);
                        queue.Enqueue(copy);
                    }
                }
            }
        }

        return result;
    }
}