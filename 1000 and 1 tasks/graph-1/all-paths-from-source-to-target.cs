public class Solution {
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        var result = new List<IList<int>>();

        var visited = new bool[graph.Length];

        var queue = new Queue<List<int>>();
        queue.Enqueue(new List<int>() {0});

        while (queue.Any()) {
            var cur = queue.Dequeue();
            var last = cur.Last();
            if (last == graph.Length - 1) {
                result.Add(cur);
            } else {
                foreach (var n in graph[last]) {
                    var copy = new List<int>();
                    copy.AddRange(cur);
                    copy.Add(n);
                    queue.Enqueue(copy);
                }
            }
        }

        return result;

    }
}