public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var j = 0;

        var prev = 101;

        for (int i = 0; i < nums.Length; i++) {
            if (prev != nums[i]) {
                nums[j++] = nums[i];
            }
            else {
                
            }
            prev = nums[i];
        }

        return j;
    }
}