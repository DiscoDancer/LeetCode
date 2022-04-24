public class Solution {
    public int MaxProduct(int[] nums) {

        
        var max = nums[0];
        var min = nums[0];
        var result = nums[0];
        
        for (int i = 1; i < nums.Length; i++) {
            var tempMax = Math.Max(nums[i], Math.Max(nums[i]*max, nums[i]*min));
            min = Math.Min(nums[i], Math.Min(nums[i]*max, nums[i]*min));
            
            max = tempMax;
            result = Math.Max(result, max);
        }
        
        return result;
    }
}