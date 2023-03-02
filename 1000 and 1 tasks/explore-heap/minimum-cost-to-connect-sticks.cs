public class Solution {
    public int ConnectSticks(int[] sticks) {
        var minHeap = new PriorityQueue<int, int>();
        foreach (var s in sticks) {
            minHeap.Enqueue(s,s);
        }

        var res = 0;
        while (minHeap.Count >= 2) {
            var a = minHeap.Dequeue();
            var b = minHeap.Dequeue();
            var ab = a + b;

            res += ab;
            minHeap.Enqueue(ab, ab);
        }

        return res;
    }
}