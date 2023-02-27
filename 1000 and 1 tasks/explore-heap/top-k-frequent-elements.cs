public class Solution {
    // немного копипасты отсюда: // https://leetcode.com/problems/kth-largest-element-in-an-array/editorial/
    // хотят тут тоже самое: https://leetcode.com/problems/top-k-frequent-elements/editorial/
    public int[] TopKFrequent(int[] nums, int k) {
        var table = new Dictionary<int, int>();
        foreach (var n in nums) {
            if (!table.ContainsKey(n)) {
                table[n] = 0;
            }
            table[n]++;
        }

        var queue = new PriorityQueue<int, int>();
        foreach (var key in table.Keys) {
            queue.Enqueue(key, table[key]);
            if (queue.Count > k) {
                queue.Dequeue();
            }
        }

        var result = new int[k];
        var i = 0;
        while (queue.TryDequeue(out var key, out var value)) {
            result[i++] = key;
        }

        return result;
    }
}