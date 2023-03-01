public class Solution {
    // сделать flat недостаточно
    // делать break на больших числах, чтобы дальше не идти (по строкам и столбикам)
    public int KthSmallest(int[][] matrix, int k) {
        var queue = new PriorityQueue<int, int>();

        foreach (var arr in matrix) {
            if (queue.Count == k && queue.Peek() <= arr[0]) {
                break;
            }
            foreach (var x in arr) {
                if (queue.Count == k && queue.Peek() <= x) {
                    break;
                }
                queue.Enqueue(x, -x);
                if (queue.Count > k) {
                    queue.Dequeue();
                }
            }
        }
        
        return queue.Peek();
    }
}