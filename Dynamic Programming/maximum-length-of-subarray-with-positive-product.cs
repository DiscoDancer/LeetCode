public class Solution {
    public int GetMaxLen(int[] nums) {
        var pos = 0;
        var neg = 0;
        var res = 0;
        
        foreach (var n in nums) {
            if (n == 0) {
                pos = 0;
                neg = 0;
            } else if (n > 0) {
                pos++;
                neg = neg == 0 ? 0 : neg + 1;
            } else { // n < 0
                var temp = pos;
                pos = neg == 0 ? 0 : neg + 1;
                neg = temp + 1;
            }
            
            res = Math.Max(res, pos);
        }
        
        return res;
    }
}