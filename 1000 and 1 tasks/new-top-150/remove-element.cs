public class Solution {
    public int RemoveElement(int[] nums, int val) {
        var j = 0;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == val) continue;

            nums[j++] = nums[i];
        }

        return j;
    }
}