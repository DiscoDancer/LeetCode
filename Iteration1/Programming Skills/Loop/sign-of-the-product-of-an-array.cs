public class Solution {
    public int ArraySign(int[] nums) {
        var isPlus = true;
        
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == 0) {
                return 0;
            }
            if (nums[i] > 0) {
                // ignore
            }
            else {
                isPlus = !isPlus;
            }
        }
        
        return isPlus ? 1 : -1;
    }
}