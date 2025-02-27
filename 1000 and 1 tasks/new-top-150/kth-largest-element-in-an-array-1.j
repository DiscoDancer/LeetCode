import java.util.Arrays;
import java.util.Collections;
import java.util.PriorityQueue;

class Solution {

    public int findKthLargest(int[] nums, int k) {
        var maxHeap = new PriorityQueue<>(Collections.reverseOrder());

        for (var x : nums) {
            maxHeap.add(x);
        }

        for (int i = 0; i < k - 1; i++) {
            var res = maxHeap.poll();
        }

        return (int)maxHeap.poll();
    }
}