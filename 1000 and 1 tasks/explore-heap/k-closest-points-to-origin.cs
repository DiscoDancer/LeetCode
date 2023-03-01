public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        var maxHeap = new PriorityQueue<int[], double>();
        foreach (var p in points) {
            var d = Math.Sqrt(p[0]*p[0] + p[1]*p[1]);
            maxHeap.Enqueue(p, -d);
            if (maxHeap.Count > k) {
                maxHeap.Dequeue();
            }
        }

        var result = new int[k][];
        var i = k - 1;
        while (maxHeap.TryDequeue(out var val, out var _)) {
            result[i--] = val;
        }

        return result;
    }
}