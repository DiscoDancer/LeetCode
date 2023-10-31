public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var pq = new PriorityQueue<int, int>();
        foreach (var n in nums) {
            pq.Enqueue(n,-n);
        }

        var result = 0;
        var i = 0;
        while (i < k) {
            result = pq.Dequeue();
            i++;
        }

        return result;
    }
}