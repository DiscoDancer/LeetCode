public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var ht = new Dictionary<int, int>();
        foreach (var n in nums) {
            if (!ht.ContainsKey(n)) {
                ht[n] = 0;
            }
            ht[n]++;
        }

        var pq = new PriorityQueue<int,int>();
        foreach (var key in ht.Keys) {
            pq.Enqueue(key, -ht[key]);
        }

        var result = new int[k];
        for (int i = 0; i < k; i++) {
            result[i] = pq.Dequeue();
        }

        return result;
    }
}