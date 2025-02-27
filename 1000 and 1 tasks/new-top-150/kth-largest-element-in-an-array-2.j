import java.util.Arrays;
import java.util.Collections;
import java.util.PriorityQueue;

class Solution {

    public int findKthLargest(int[] nums, int k) {
        var minHeap = new PriorityQueue<Integer>();

        for (var x : nums) {
            if (minHeap.size() < k) {
                minHeap.add(x);
            } else {
                var curMin = minHeap.peek();
                if (x > curMin) {
                    minHeap.poll();
                    minHeap.add(x);
                }
            }
        }


        return minHeap.poll();
    }
}