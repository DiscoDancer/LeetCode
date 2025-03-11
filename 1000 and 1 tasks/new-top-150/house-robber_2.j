class Solution {

    private int[] nums;

    private int F(int index) {
        if (index >= nums.length) {
            return 0;
        }

        var robOption = F(index + 2) + nums[index];
        var notRobOption = F(index + 1);

        return Math.max(notRobOption, robOption);
    }

    public int rob(int[] nums) {
        this.nums = nums;

        return F(0);
    }
}