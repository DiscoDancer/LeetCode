public class Solution {
    public void MoveZeroes(int[] nums) {
        var slow = 0;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != 0) {
                nums[slow++] = nums[i];
            }
        }

        while (slow < nums.Length) {
            nums[slow++] = 0;
        }
    }
}