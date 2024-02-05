public class Solution {
    // dp
    // obviously heap
    public int ConnectSticks(int[] sticks) {
        var pq = new PriorityQueue<int, int>();
        foreach (var x in sticks) {
            pq.Enqueue(x, x);
        }

        var result = 0;

        while (pq.Count > 1) {
            var a = pq.Dequeue();
            var b = pq.Dequeue();

            result += a + b;
            pq.Enqueue(a + b, a + b);
        }

        return result;
    }
}