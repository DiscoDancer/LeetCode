class Solution {
    public int rob(int[] nums) {
        var table = new int[nums.length + 2];

        for (int i = nums.length - 1; i >= 0; i--) {
            table[i] = Math.max(nums[i] + table[i+2], table[i+1]);
        }

        return table[0];
    }
}
