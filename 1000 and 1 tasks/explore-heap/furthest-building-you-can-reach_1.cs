public class Solution {
    // https://leetcode.com/problems/furthest-building-you-can-reach/submissions/
    public int FurthestBuilding(int[] heights, int bricks, int ladders) {
        var minHeap = new PriorityQueue<int, int>();

        for (int i = 0; i < heights.Length - 1; i++) {
            var diff = heights[i + 1] - heights[i];

            if (diff <= 0) {
                continue;
            }

            minHeap.Enqueue(diff, diff);
            if (minHeap.Count <= ladders) {
                continue;
            }

            bricks -= minHeap.Dequeue();
            if (bricks < 0) {
                return i;
            }
        }

        return heights.Length - 1;
    }
}