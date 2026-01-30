import java.util.*;

class Solution {

    public int findKthLargest(int[] nums, int k) {
        PriorityQueue<Integer> minHeap = new PriorityQueue<>();

        for (var x: nums) {
            if (minHeap.size() < k) {
                minHeap.add(x);
            }
            else {
                if (minHeap.peek() >= x) {
                    // ignore
                }
                else {
                    minHeap.poll();
                    minHeap.add(x);
                }
            }
        }

        return minHeap.poll();
    }
}