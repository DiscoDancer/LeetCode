public class Solution {
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        var n = graph.Length;
        var result = new List<IList<int>>();
        
        var queue = new Queue<List<int>>();
        queue.Enqueue(new List<int>(){0});

        while (queue.Any()) {
            var path = queue.Dequeue();
            if (path.Last() == n - 1) {
                result.Add(path);
            }
            else {
                foreach (var x in graph[path.Last()]) {
                    var copy = path.ToList();
                    copy.Add(x);
                    queue.Enqueue(copy);
                }
            }
        }

        return result;
    }
}