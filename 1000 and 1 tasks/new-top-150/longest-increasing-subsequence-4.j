// TL
// размерность лучше

class Solution {

    private int[] nums;

    private int F(int i, int acc, int startI) {
        if (i == this.nums.length) {
            return acc;
        }

        var firstNumInSequence = startI >= 0 ? this.nums[startI] : Integer.MAX_VALUE;

        var max = 0;

        if (nums[i] > firstNumInSequence) {
            // продолжить
            max = Math.max(max, F(i + 1, acc + 1, i));
        }
        else if (nums[i] < firstNumInSequence) {
            // начать заново
            max = Math.max(max, F(i + 1, 1, i));
        }
        // пропустить
        max = Math.max(max, F(i + 1, acc, startI));

        return max;
    }

    public int lengthOfLIS(int[] nums) {
        this.nums = nums;

        return F(0, 1, -1);
    }
}