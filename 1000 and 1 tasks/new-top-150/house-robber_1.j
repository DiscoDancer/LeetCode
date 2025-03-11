class Solution {

    private int[] nums;

    // still TL

    private int F(int index, boolean allowToRob) {
        if (index == nums.length) {
            return 0;
        }

        var robOption = allowToRob ? F(index + 1, false) + nums[index] : 0;
        var notRobOption = F(index + 1, true);

        return Math.max(notRobOption, robOption);
    }

    public int rob(int[] nums) {
        this.nums = nums;

        return F(0, true);
    }
}