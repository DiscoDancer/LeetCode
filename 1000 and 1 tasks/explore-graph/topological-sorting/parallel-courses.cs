public class Solution {
    // n cources 1..n
    // relations[i] = [prevCoursei, nextCoursei]
    public int MinimumSemesters(int n, int[][] relations) {
        var table = new (List<int> prevList, List<int> nextList)[n];
        for (int i = 0; i < n; i++) {
            table[i] = (new List<int>(), new List<int>());
        }

        foreach (var rel in relations) {
            var prev = rel[0] - 1;
            var next = rel[1] - 1;
            table[prev].nextList.Add(next);
            table[next].prevList.Add(prev);
        }

        var generation = new int[n];

        var queue = new Queue<int>();
        for (int i = 0; i < n; i++) {
            if (!table[i].nextList.Any()) {
                queue.Enqueue(i);
                generation[i] = 1;
            }
        }

        while (queue.Any()) {
            var cur = queue.Dequeue();
            foreach (var prev in table[cur].prevList) {
                table[prev].nextList.Remove(cur);
                if (!table[prev].nextList.Any()) {
                    queue.Enqueue(prev);
                    generation[prev] = generation[cur] + 1;
                }
            }
        }

        var min = generation.Min();
        if (min == 0) {
            return -1;
        }

        return generation.Max();
    }
}