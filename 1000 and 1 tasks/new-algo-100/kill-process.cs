public class Solution {
    public IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill) {
        var n = pid.Count();
        var childrenTable = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++) {
            var id = pid[i];
            var parentId = ppid[i];
            if (!childrenTable.ContainsKey(parentId)) {
                childrenTable[parentId] = new ();
            }
            childrenTable[parentId].Add(id);
        }

        var queue = new Queue<int>();
        var result = new List<int>();
        queue.Enqueue(kill);

        while (queue.Any()) {
            var cur = queue.Dequeue();
            result.Add(cur);
            if (childrenTable.ContainsKey(cur)) {
                foreach (var c in childrenTable[cur]) {
                    queue.Enqueue(c);
                }
            }
        }

        return result;
    }
}