import java.util.*;

class Solution {

    public int minStoneSum(int[] piles, int k) {
        PriorityQueue<Integer> maxHeap =
                new PriorityQueue<>((a, b) -> b- a);
        for (var i = 0; i < piles.length; i++) {
            maxHeap.add(piles[i]);
        }

        while (k-- > 0) {
            var max = maxHeap.poll();
            var newValue = max - (int)Math.floor(max / 2);
            maxHeap.add(newValue);
        }

        var sum = 0;
        while (maxHeap.size() > 0) {
            sum += maxHeap.poll();
        }
        
        return sum;
    }
}