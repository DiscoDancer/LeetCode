import java.util.*;

// TL

class Solution {

    public record Entry(int i1, int i2) {
        public int sum() {
            return i1 + i2;
        }
    }

    public List<List<Integer>> kSmallestPairs(int[] nums1, int[] nums2, int k) {
        var maxHeap = new PriorityQueue<Entry>((a,b) ->  -a.sum() + b.sum());
        for (int i = 0; i < nums1.length; i++) {
            for (int j = 0; j < nums2.length; j++) {
                var size = maxHeap.size();
                if (size < k) {
                    maxHeap.add(new Entry(nums1[i], nums2[j]));
                }
                else {
                    var maxSumInHeap = maxHeap.peek().sum();
                    var candidateSum = nums1[i] + nums2[j];
                    if (candidateSum >= maxSumInHeap) {
                        // do nothing
                    }
                    else {
                        maxHeap.poll();
                        maxHeap.add(new Entry(nums1[i], nums2[j]));
                    }
                }
            }
        }

        var result = new ArrayList<List<Integer>>(k);
        while (!maxHeap.isEmpty()) {
            var entry = maxHeap.poll();
            result.add(List.of(entry.i1, entry.i2));
        }


        return result;
    }
}