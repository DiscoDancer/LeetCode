public class Solution {
    public void MoveZeroes(int[] nums) {
        var firstZeroIndex = -1;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != 0) {
                if (firstZeroIndex < 0) {
                    continue;
                }
                else {
                    nums[firstZeroIndex] = nums[i];
                    nums[i] = 0;
                    firstZeroIndex++;
                }
            }
            else { // is zero
                if (firstZeroIndex < 0) { 
                    firstZeroIndex = i;
                }
                else {
                    continue;
                }
            }
        }
    }
}