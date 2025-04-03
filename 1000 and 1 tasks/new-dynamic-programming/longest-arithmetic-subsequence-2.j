import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashMap;
import java.util.PriorityQueue;

class Solution {
    public record Entry(int diff, int score) {}

    public int longestArithSeqLength(int[] nums) {
        @SuppressWarnings("unchecked")
        var table = (HashMap<Integer, Integer>[]) new HashMap[nums.length];
        // diff -> MaxCount for each i

        var max = 0;

        for (var i = 0; i < nums.length; i++) {
            table[i] = new HashMap<>();
            for (var j = i-1; j >=0 ; j--) {
                var diff = nums[i] - nums[j];
                var count = 2;

                if (table[j].containsKey(diff)) {
                    count = table[j].get(diff) + 1;
                }

                if (!table[i].containsKey(diff)) {
                    table[i].put(diff, count);
                }
                else {
                    table[i].put(diff, Math.max(count, table[i].get(diff)));
                }

                max = Math.max(max, count);
            }
        }

        return max;
    }
}