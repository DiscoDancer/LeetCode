class Solution {
    public int rob(int[] nums) {
        var table = new int[nums.length + 2];
        for (int i = nums.length - 1; i >= 0; i--) {
            table[i] = Math.max(table[i + 1], table[i + 2] + nums[i]);
        }

        return table[0];
    }
}