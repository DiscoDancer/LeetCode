public class Solution {
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        var result = new List<IList<int>>();

        var queue = new Queue<List<int>>();
        queue.Enqueue(new List<int>() {0});

        while (queue.Any()) {
            var cur = queue.Dequeue();
            var last = cur.Last();
            if (last == graph.Length - 1) {
                result.Add(cur);
            } else {
                // false backtracking
                foreach (var n in graph[last]) {
                    cur.Add(n);
                    queue.Enqueue(cur.ToList());
                    cur.Remove(n);
                }
            }
        }

        return result;

    }
}