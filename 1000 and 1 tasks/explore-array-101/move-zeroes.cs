public class Solution {
    // count zeroes
    public void MoveZeroes(int[] nums) {
        var newIndex = 0;
        var countZeroes = 0;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != 0) {
                nums[newIndex++] = nums[i];
            }
            else {
                countZeroes++;
            }
        }

        for (int i = 0; i < countZeroes; i++) {
            var j = nums.Length - 1 - i;
            nums[j] = 0;
        }
    }
}