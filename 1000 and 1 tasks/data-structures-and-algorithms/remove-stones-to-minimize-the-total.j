import java.util.*;

class Solution {

    public record IndexValue(int index, int value) {}

    public int minStoneSum(int[] piles, int k) {
        PriorityQueue<IndexValue> maxHeap =
                new PriorityQueue<>((a, b) -> b.value() - a.value());
        for (var i = 0; i < piles.length; i++) {
            maxHeap.add(new IndexValue(i, piles[i]));
        }

        while (k-- > 0) {
            var max = maxHeap.poll();
            var newValue = max.value - (int)Math.floor(max.value / 2);
            maxHeap.add(new IndexValue(max.index, newValue));
        }

        var sum = 0;
        while (maxHeap.size() > 0) {
            sum += maxHeap.poll().value;
        }




        return sum;
    }
}