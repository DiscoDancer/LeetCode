class Solution {
    public int rob(int[] nums) {

        var prevPrev = 0;
        var prev = 0;

        for (int i = nums.length - 1; i >= 0; i--) {
            var cur = Math.max(nums[i] + prevPrev, prev);
            prevPrev = prev;
            prev = cur;
        }

        return prev;
    }
}
