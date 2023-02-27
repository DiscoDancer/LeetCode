public class Solution {
    // это проходит, но не очень оптимально
    public int FindKthLargest(int[] nums, int k) {
        var queue = new PriorityQueue<int, int>();
        foreach(var n in nums) {
            queue.Enqueue(n,-n);
        }

        var i = 1;
        while (i < k) {
            queue.Dequeue();
            i++;
        }

        return queue.Peek();
    }
}