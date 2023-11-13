public class Solution {
    // table can be removed
    public int Rob(int[] nums) {
        _nums = nums;

        var table = new int[nums.Length + 1, 2];
        // explicit
        table[nums.Length, 0] = 0;
        table[nums.Length, 1] = 0;

        for (int i = nums.Length - 1; i >= 0; i--) {
            for (var take = 0; take < 2; take++) {
                if (take == 0) {
                    table[i, 0] = table[i+1, 1]; 
                }
                else if (take == 1) {
                    table[i, 1] = Math.Max(table[i+1, 0] + nums[i], table[i+1, 1]); 
                }
            }
        }

        return Math.Max(table[0,0], table[0,1]);
    }
}