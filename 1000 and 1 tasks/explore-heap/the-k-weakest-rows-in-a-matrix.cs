public class Solution {
    // если weakest значит обратно (lowest)
    // приоритет должен учитывать количество солдат и индекс
    // пример 3.0001 3 солдата, 1 индекс
    public int[] KWeakestRows(int[][] mat, int k) {
        var queue = new PriorityQueue<int, double>();
        for (int rowIndex = 0; rowIndex < mat.Length; rowIndex++) {
            var arr = mat[rowIndex];

            var soliersCount = 0;
            while (soliersCount < arr.Length && arr[soliersCount] == 1) {
                soliersCount++;
            }
            const double BigNumber = 10000.0;
            var priority = soliersCount + (double)rowIndex / BigNumber;
            queue.Enqueue(rowIndex, - priority);
            if (queue.Count > k) {
                queue.Dequeue();
            }
        }

        var result = new int[k];
        int j = queue.Count - 1;
        while (queue.TryDequeue(out var val, out var pr)) {
            result[j--] = val;
        }

        return result;
    }
}