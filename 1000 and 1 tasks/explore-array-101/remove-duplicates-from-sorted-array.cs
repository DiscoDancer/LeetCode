public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var length = nums.Length;
        
        for (int i = 0; i < length; i++) {
            if (i > 0 && nums[i-1] == nums[i]) {
                for (int j = i; j < length - 1; j++) {
                    nums[j] = nums[j+1];
                }
                length--;
                if (i > 0 && nums[i-1] == nums[i]) {
                    i--;
                }
            }
        }

        return length;
    }
}