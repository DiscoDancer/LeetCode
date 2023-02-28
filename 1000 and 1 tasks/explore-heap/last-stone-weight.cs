public class Solution {
    public int LastStoneWeight(int[] stones) {
        var queue = new PriorityQueue<int, int>();
        foreach (var s in stones) {
            queue.Enqueue(s, -s);
        }

        while (queue.Count >= 2) {
            var y = queue.Dequeue();
            var x = queue.Dequeue();
            var z = y - x;
            if (z > 0) {
                queue.Enqueue(z, -z);
            }
        }

        if (queue.Count > 0) {
            return queue.Dequeue();
        }

        return 0;
    }
}