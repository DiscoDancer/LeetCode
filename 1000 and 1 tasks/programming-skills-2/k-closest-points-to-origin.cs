public class Solution {
    // мм, просто очередь с приоритетом?
    public int[][] KClosest(int[][] points, int k) {
        var queue = new PriorityQueue<(int x, int y), double>();

        foreach (var p in points) {
            var d = Math.Sqrt(p[0]*p[0] + p[1]*p[1]);
            queue.Enqueue((p[0], p[1]), d);
        }

        var res = new int[k][];

        var kk = 0;
        while (kk < k && queue.TryDequeue(out var val, out var _)) {
            res[kk] = new int[] {val.x, val.y};
            kk++;
        }

        return res;
    }
}