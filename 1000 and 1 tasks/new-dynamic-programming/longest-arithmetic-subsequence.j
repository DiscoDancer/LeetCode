import java.util.Comparator;
import java.util.HashMap;
import java.util.PriorityQueue;

class Solution {

    private int[] nums;
    private int max = 1;

    private void F(int i, int prevI, Integer diff, int score) {
        if (i == nums.length) {
            this.max = Math.max(this.max, score);
            return;
        }
        if (i == 0) {
            // take the first element
            F(i + 1, i, null, 1);
            // skip the first element
            F(i + 1, -1, null, 1);
        }
        else {
            if (prevI == -1) {
                // can continue skipping
                F(i + 1, -1, null, 1);
                // take this element as first
                F(i + 1, i, null, 1);
            }
            else {
                if (diff == null) {
                    // can take it unconditionally
                    F(i + 1, i, nums[i] - nums[prevI], 2);
                }
                else if (nums[i] - nums[prevI] == diff) {
                    // take regarding the diff
                    F(i + 1, i, diff, score + 1);
                }
                // skip
                F(i + 1, prevI, diff, score);
            }
        }
    }

    public int longestArithSeqLength(int[] nums) {
        this.nums = nums;


        F(0, -1, null, 1);


        return this.max;
    }
}