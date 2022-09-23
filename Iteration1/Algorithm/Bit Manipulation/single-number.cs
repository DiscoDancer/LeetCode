public class Solution {
    public int SingleNumber(int[] nums) {
        var res = 0;
        
        foreach (var n in nums) {
            // res = ~res & n | res & ~n;
            res = res ^ n;
        }
        
        return res;
    }
}