public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var i = 0;

        for (int j = 0; j < nums.Length; j++) {
            if (j > 0 && nums[j] != nums[j-1]) {
                nums[i++] = nums[j];
            }
            else if (j == 0) {
                i++;
            }
        }

        return i;
    }
}