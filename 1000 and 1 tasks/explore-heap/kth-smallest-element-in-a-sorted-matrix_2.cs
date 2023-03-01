public class Solution {

    // https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/editorial/

    public class MyHeapNode {
        public int row { get; set; }
        public int column { get; set; }
        public int value { get; set; }
    }

    public int KthSmallest(int[][] matrix, int k) {
        var N = matrix.Length;
        var minHeap = new PriorityQueue<MyHeapNode, int>();

        for (int r = 0; r < Math.Min(N, k); r++) {
            var data = new MyHeapNode() {
                row = r,
                column = 0,
                value = matrix[r][0]
            };
            minHeap.Enqueue(data, matrix[r][0]);
        }

        MyHeapNode element = null;
        while (k-- > 0) {
            element = minHeap.Dequeue();
            if (element.column < N - 1) {
                var nova = new MyHeapNode() {
                    row = element.row,
                    column = element.column + 1,
                    value = matrix[element.row][element.column + 1]
                };
                minHeap.Enqueue(nova, matrix[element.row][element.column + 1]);
            }
        }

        return element.value;
    }
}