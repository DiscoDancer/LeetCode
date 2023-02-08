public class Solution {
    // n cources 1..n
    // relations[i] = [prevCoursei, nextCoursei]
    public int MinimumSemesters(int n, int[][] relations) {
        var table = new (List<int> prevList, int nextCount)[n];
        for (int i = 0; i < n; i++) {
            table[i] = (new List<int>(), 0);
        }

        foreach (var rel in relations) {
            var prev = rel[0] - 1;
            var next = rel[1] - 1;
            table[next].prevList.Add(prev);
            table[prev] = (table[prev].prevList, table[prev].nextCount + 1);
        }

        var generation = new int[n];
        var zeroGenCount = n;
        var maxGen = relations.Any() ? 1 : 0;

        var queue = new Queue<int>();
        for (int i = 0; i < n; i++) {
            if (table[i].nextCount == 0) {
                queue.Enqueue(i);
                generation[i] = 1;
                zeroGenCount--;
            }
        }

        while (queue.Any()) {
            var cur = queue.Dequeue();
            foreach (var prev in table[cur].prevList) {
                table[prev].nextCount--;
                if (table[prev].nextCount == 0) {
                    queue.Enqueue(prev);
                    generation[prev] = generation[cur] + 1;
                    zeroGenCount--;
                    maxGen = Math.Max(maxGen, generation[prev]);
                }
            }
        }

        if (zeroGenCount != 0) {
            return -1;
        }

        return maxGen;
    }
}