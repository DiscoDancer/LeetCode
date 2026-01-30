import java.util.*;

class Solution {

    public int connectSticks(int[] sticks) {
        PriorityQueue<Integer> minHeap = new PriorityQueue<>();
        for (var x: sticks) {
            minHeap.add(x);
        }
        
        var result = 0;
        
        while (minHeap.size() > 1) {
            var a = minHeap.poll();
            var b = minHeap.poll();
            result += (a + b);
            minHeap.add(a+b);
        }
        
        return result;
    }
}