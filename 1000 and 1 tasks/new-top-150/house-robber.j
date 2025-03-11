class Solution {

    private int[] nums;
    private int max = 0;

    private void F(int index, boolean allowToRob, int gain) {
        if (index == nums.length) {
            this.max = Math.max(this.max, gain);
            return;
        }

        if (allowToRob) {
            // rob
            F(index + 1, false, gain + nums[index]);
        }
        // not rob
        F(index + 1, true, gain);
    }

    public int rob(int[] nums) {
        this.nums = nums;

        F(0, true, 0);

        return this.max;
    }
}