import java.util.List;

// TL

class Solution {

    private int[] nums;
    private int max;

    private void F(int i, int acc, int lastNum) {
        this.max = Math.max(acc, this.max);

        if (i == this.nums.length) {
            return;
        }

        if (nums[i] > lastNum) {
            // продолжить
            F(i + 1, acc + 1, nums[i]);
        }
        // пропустить
        F(i + 1, acc, lastNum);
        // начать заново
        F(i + 1, 1, nums[i]);
    }

    public int lengthOfLIS(int[] nums) {
        this.nums = nums;
        this.max = 1;

        F(0, 0, Integer.MAX_VALUE);

        return this.max;
    }
}