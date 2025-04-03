import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashMap;
import java.util.PriorityQueue;

class Solution {
    public record Entry(int diff, int score) {}

    public int longestArithSeqLength(int[] nums) {
        @SuppressWarnings("unchecked")
        var table = (ArrayList<Entry>[]) new ArrayList[nums.length];

        var max = 0;

        for (var i = 0; i < nums.length; i++) {
            table[i] = new ArrayList<>();
            for (var j = i-1; j >=0 ; j--) {
                var diff = nums[i] - nums[j];
                var count = 2;

                for (var x: table[j]) {
                    if (x.diff == diff) {
                        count = Math.max(count, x.score + 1);
                    }
                }

                table[i].add(new Entry(diff, count));
                max = Math.max(max, count);
            }
        }

        return max;
    }
}