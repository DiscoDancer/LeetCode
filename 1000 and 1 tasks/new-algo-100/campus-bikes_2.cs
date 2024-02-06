public class Solution {
    // editorial
    public int[] AssignBikes(int[][] workers, int[][] bikes) {
                var pairsHeap = new PriorityQueue<(int wi, int bi, int d), (int wi, int bi, int d)>(
            Comparer<(int wi, int bi, int d)>.Create((a, b) =>
            {
                if (a.d != b.d)
                {
                    return a.d.CompareTo(b.d);
                }

                if (a.wi != b.wi)
                {
                    return a.wi.CompareTo(b.wi);
                }

                return a.bi.CompareTo(b.bi);
            }));

        var bikesByWorker = new int[workers.Length][];
        var bikesByWorkerIndexes = new int[workers.Length];

        for (var wi = 0; wi < workers.Length; wi++)
        {
            var arr = new (int bi, int d)[bikes.Length];
            for (var bi = 0; bi < bikes.Length; bi++)
            {
                var d = Math.Abs(workers[wi][0] - bikes[bi][0]) + Math.Abs(workers[wi][1] - bikes[bi][1]);
                arr[bi] = (bi, d);
            }

            bikesByWorker[wi] = arr.OrderBy(x => x.d).Select(x => x.bi).ToArray();

            var bestBi = bikesByWorker[wi][0];
            var bestD = Math.Abs(workers[wi][0] - bikes[bestBi][0]) + Math.Abs(workers[wi][1] - bikes[bestBi][1]);
            pairsHeap.Enqueue((wi, bestBi, bestD), (wi, bestBi, bestD));
            bikesByWorkerIndexes[wi]++;
        }

        var result = new int[workers.Length];
        var isBikeInUse = new bool[bikes.Length];
        var isWorkerAssigned = new bool[workers.Length];
        var assignedCount = 0;
        while (assignedCount < workers.Length && pairsHeap.Count > 0)
        {
            var (wi, bi, d) = pairsHeap.Dequeue();

            if (!isWorkerAssigned[wi] && !isBikeInUse[bi])
            {
                isBikeInUse[bi] = true;
                isWorkerAssigned[wi] = true;
                result[wi] = bi;
                assignedCount++;
            }
            else
            {
                var bestBi = bikesByWorker[wi][bikesByWorkerIndexes[wi]];
                var bestD = Math.Abs(workers[wi][0] - bikes[bestBi][0]) + Math.Abs(workers[wi][1] - bikes[bestBi][1]);
                pairsHeap.Enqueue((wi, bestBi, bestD), (wi, bestBi, bestD));
                bikesByWorkerIndexes[wi]++;
            }
        }

        return result;
    }
}