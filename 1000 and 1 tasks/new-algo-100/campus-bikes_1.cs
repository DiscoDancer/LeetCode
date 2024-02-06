public class Solution {
    public int[] AssignBikes(int[][] workers, int[][] bikes) {
        // todo sort first by d, then by wi
        var pq = new PriorityQueue<(int wi, int bi, int d), (int wi, int bi, int d)>(
            Comparer<(int wi, int bi, int d)>.Create((a, b) =>
            {
                if (a.d != b.d) {
                    return a.d.CompareTo(b.d);
                }

                if (a.wi != b.wi) {
                    return a.wi.CompareTo(b.wi);
                }

                return a.bi.CompareTo(b.bi);
            }));

        for (int wi = 0; wi < workers.Length; wi++)
        {
            for (int bi = 0; bi < bikes.Length; bi++)
            {
                var d = Math.Abs(workers[wi][0] - bikes[bi][0]) + Math.Abs(workers[wi][1] - bikes[bi][1]);
                pq.Enqueue((wi, bi, d), (wi, bi, d));
            }
        }

        var result = new int[workers.Length];
        var isBikeInUse = new bool[bikes.Length];
        var isWorkerAssigned = new bool[workers.Length];
        var assignedCount = 0;
        while (assignedCount < workers.Length && pq.Count > 0)
        {
            var (wi, bi, d) = pq.Dequeue();
            if (isWorkerAssigned[wi] || isBikeInUse[bi])
            {
                continue;
            }

            result[wi] = bi;
            assignedCount++;
            isBikeInUse[bi] = true;
            isWorkerAssigned[wi] = true;
        }

        return result;
    }
}