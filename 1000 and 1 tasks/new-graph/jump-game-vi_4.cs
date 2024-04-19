
// TL
public class Solution {
    public int MaxResult(int[] nums, int k) {
        var table = new long[nums.Length];
        table[nums.Length-1] = nums[nums.Length-1];

        for (int index = nums.Length-2; index >= 0; index--) {
            long max = long.MinValue;
            
            for (int i = 1; i <= k && index + i < nums.Length ; i++) {
                max = Math.Max(max,  table[index + i]);
            }
            
            table[index] = nums[index] + max;
        }

        return (int)table[0];
    }
}