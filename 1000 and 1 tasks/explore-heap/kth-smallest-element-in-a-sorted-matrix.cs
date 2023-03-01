public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        var queue = new PriorityQueue<int, int>();

        foreach (var arr in matrix) {
            foreach (var x in arr) {
                queue.Enqueue(x, -x);
                if (queue.Count > k) {
                    queue.Dequeue();
                }
            }
        }
        
        return queue.Peek();
    }
}