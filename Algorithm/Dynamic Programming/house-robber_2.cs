public class Solution {
    public int Rob(int[] nums) {
        var n = nums.Length;
        
        var prevPlusOne = 0;
        var prev = nums[n - 1];
        
        for (int i = n - 2; i >= 0; i--) {
            var cur = Math.Max(prev, prevPlusOne + nums[i]);
            prevPlusOne = prev;
            prev = cur;
        }
        
        return prev;
    }
}