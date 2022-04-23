public class Solution {
    public int Jump(int[] nums) {        
        
        var farest = 0;
        var jumpEnd = 0;
        var res = 0;
        for (var i = 0; i < nums.Length - 1; i++) {
            farest = Math.Max(farest, i + nums[i]);
            if (i == jumpEnd) {
                jumpEnd = farest;
                res++;
            }
        }
        
        return res;
    }
}