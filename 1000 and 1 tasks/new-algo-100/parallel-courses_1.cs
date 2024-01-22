public class Solution {
    // topologic sort
    // matrix also works
    public int MinimumSemesters(int n, int[][] relations) {
        var outcomingCount = new int[n+1];
        var incomingTable = new List<int>[n+1];

        for (int i = 1; i <= n; i++) {
            incomingTable[i] = new ();
        }

        foreach (var ab in relations) {
            // a -> b
            var a = ab[0];
            var b = ab[1];
            outcomingCount[a]++;
            incomingTable[b].Add(a);
        }

        var queue = new Queue<int>();
        for (int i = 1; i <= n; i++) {
            if (outcomingCount[i] == 0) {
                queue.Enqueue(i);
            }
        }

        var totalRemaining = n;
        var semesterCount = 0;
        while (queue.Any()) {
            semesterCount++;
            var size = queue.Count();
            for (int i = 0; i < size; i++) {
                var cur = queue.Dequeue();
                foreach (var inc in incomingTable[cur]) {
                    outcomingCount[inc]--;
                    if (outcomingCount[inc] == 0) {
                        queue.Enqueue(inc);
                    }
                }
                totalRemaining--;
            }
        }

        return totalRemaining == 0 ? semesterCount : -1;
    }
}