import java.util.Arrays;
import java.util.Collections;
import java.util.Comparator;
import java.util.PriorityQueue;

class Solution {

    public int hIndex(int[] citations) {
        PriorityQueue<Integer> maxHeap = new PriorityQueue<>(Collections.reverseOrder());

        for (int citation : citations) {
            maxHeap.offer(citation);
        }

        var count = 0;
        var maxScore = 0;
        while (!maxHeap.isEmpty()) {
            count++;
            var cur = maxHeap.poll();

            var curScore = Math.min(count, cur);
            maxScore = Math.max(maxScore, curScore);

            if (curScore < count) {
                break;
            }
        }

        return maxScore;
    }
}
