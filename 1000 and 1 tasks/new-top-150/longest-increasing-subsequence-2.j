import java.util.List;

// TL

class Solution {

    private int[] nums;

    private int F(int i, int acc, int lastNum) {
        if (i == this.nums.length) {
            return acc;
        }

        var max = 0;

        if (nums[i] > lastNum) {
            // продолжить
            max = Math.max(max, F(i + 1, acc + 1, nums[i]));
        }
        else {
            // начать заново
            max = Math.max(max, F(i + 1, 1, nums[i]));
        }
        // пропустить
        max = Math.max(max, F(i + 1, acc, lastNum));
        
        return max;
    }

    public int lengthOfLIS(int[] nums) {
        this.nums = nums;

        return F(0, 1, Integer.MAX_VALUE);
    }
}