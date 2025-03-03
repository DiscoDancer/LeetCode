import java.util.*;

// memory limit

class Solution {

    public record Entry(int i1, int i2) {
        public int sum() {
            return i1 + i2;
        }
    }

    public List<List<Integer>> kSmallestPairs(int[] nums1, int[] nums2, int k) {
        var pq = new PriorityQueue<Entry>((a,b) -> a.sum() - b.sum());
        for (int i = 0; i < nums1.length; i++) {
            for (int j = 0; j < nums2.length; j++) {
                pq.add(new Entry(nums1[i], nums2[j]));
            }
        }

        var result = new ArrayList<List<Integer>>(k);
        for (int i = 0; i < k; i++) {
            var entry = pq.poll();
            if (entry == null) {
                break;
            }
            result.add(List.of(entry.i1, entry.i2));
        }


        return result;
    }
}