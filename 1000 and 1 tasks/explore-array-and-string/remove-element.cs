public class Solution {
    public int RemoveElement(int[] nums, int val) {
        var j = 0;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == val) {
                // nothing
            }
            else {
                nums[j] = nums[i];
                j++;
            }
        }

        return j;
    }
}