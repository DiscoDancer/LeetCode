public class Solution {
    public int FindKthLargest(int[] nums, int k) {
        var queue = new PriorityQueue<int, int>();
        foreach(var n in nums) {
            queue.Enqueue(n,n);
            if (queue.Count > k) {
                queue.Dequeue();
            }
        }

        return queue.Peek();
    }
}