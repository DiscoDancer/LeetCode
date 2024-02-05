public class Solution {
    // от 0 считать не получится
    // мб несколько очередей по всем координатам
    // решить хоть как нибудь
    // положить все точки одну кучу, ее отсортировать по М


    // TL -> n*n*n
    public int[] AssignBikes(int[][] workers, int[][] bikes) {
        
        var workersCount = workers.Length;

        var workersMap = new bool[workers.Length];
        var bikesMap = new bool[bikes.Length];

        var result = new int[workers.Length];

        for (int k = 0; k < workersCount; k++) {

            var minDistance = int.MaxValue;
            var minWorkerIndex = -1;
            var minBikeIndex = -1;

            for (var wi = 0; wi < workers.Length; wi++) {
                for (var bi = 0; bi < bikes.Length; bi++) {
                    if (!workersMap[wi] && !bikesMap[bi]) {
                        var d = Math.Abs(workers[wi][0] - bikes[bi][0]) + Math.Abs(workers[wi][1] - bikes[bi][1]);
                        if (d < minDistance) {
                            minDistance = d;
                            minWorkerIndex = wi;
                            minBikeIndex = bi;
                        }
                    }
                }
            }

            workersMap[minWorkerIndex] = true;
            bikesMap[minBikeIndex] = true;
            result[minWorkerIndex] = minBikeIndex;
        }

        return result;
    }
}