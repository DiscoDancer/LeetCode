public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        var cur0 = new List<int>();
        var pool0 = Enumerable.Range(1, n).ToList();

        var queue = new Queue<(List<int> cur, List<int> pool)>();
        queue.Enqueue((cur0, pool0));

        var result = new List<IList<int>>();

        while (queue.Any()) {
            var (cur, pool) = queue.Dequeue();

            if (cur.Count() == k) {
                result.Add(cur);
            }
            
            int i = 1;
            foreach (var p in pool) {
                var newCur = cur.ToList();
                newCur.Add(p);
                var newPool = pool.Skip(i).ToList();
                queue.Enqueue((newCur, newPool));
                i++; 
            }
        }

        return result;
    }
}