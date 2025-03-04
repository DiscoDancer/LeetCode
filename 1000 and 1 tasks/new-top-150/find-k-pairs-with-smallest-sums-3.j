import java.util.*;

// based on editorial idea

class Solution {

    private static int[] nums1;
    private static int[] nums2;

    public record Entry(int i1, int i2) {
        public int sum() {
            return nums1[i1] + nums2[i2];
        }
    }

    public List<List<Integer>> kSmallestPairs(int[] nums1, int[] nums2, int k) {
        this.nums1 = nums1;
        this.nums2 = nums2;

        var result = new ArrayList<List<Integer>>();

        var minHeap = new PriorityQueue<Entry>((a,b) -> a.sum() - b.sum());
        minHeap.add(new Entry(0, 0));

        var hashSet = new HashSet<Entry>();

        var curK = 0;
        while (curK < k && !minHeap.isEmpty()) {
            var entry = minHeap.poll();
            result.add(List.of(nums1[entry.i1], nums2[entry.i2]));

            var e1 = new Entry(entry.i1 + 1, entry.i2);
            if (entry.i1 < nums1.length - 1 && !hashSet.contains(e1)) {
                minHeap.add(e1);
                hashSet.add(e1);
            }

            var e2 = new Entry(entry.i1, entry.i2 + 1);
            if (entry.i2 < nums2.length - 1 && !hashSet.contains(e2)) {
                minHeap.add(e2);
                hashSet.add(e2);
            }

            curK++;
        }

        return result;
    }
}