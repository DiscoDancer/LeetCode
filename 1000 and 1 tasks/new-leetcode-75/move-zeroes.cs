public class Solution {
    public void MoveZeroes(int[] nums) {
        var j = 0;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != 0) {
                nums[j++] = nums[i];
            }
        }

        while (j < nums.Length) {
            nums[j++] = 0;
        }
    }
}