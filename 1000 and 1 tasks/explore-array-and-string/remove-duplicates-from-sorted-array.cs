public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var prev = nums[0];
        var j = 1; // slow
        for (int i = 1; i < nums.Length; i++) {
            var cur = nums[i];
            if (prev == cur) {
                // 
            }
            else {
                nums[j++] = cur;
            }

            prev = cur;
        }

        return j;
    }
}