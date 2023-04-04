public class Solution {
    // count zeroes
    public void MoveZeroes(int[] nums) {
        var newIndex = 0;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != 0) {
                nums[newIndex++] = nums[i];
            }
        }

        while (newIndex < nums.Length) {
            nums[newIndex++] = 0;
        }
    }
}