public class Solution {
    public int SpecialArray(int[] nums) {
        for (int i = 1; i <= nums.Length; i++) {
            var k = 0;
            for (int j = 0; j < nums.Length; j++) {
                if (nums[j] >= i) {
                    k++;
                }
            }
            if (k == i) {
                return k;
            }
        }
        
        return -1;
    }
}