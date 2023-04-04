public class Solution {
    public int[] SortArrayByParity(int[] nums) {
        var globalIndex = 0;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] % 2 == 0) {
                var tmp = nums[globalIndex];
                nums[globalIndex] = nums[i];
                nums[i] = tmp;
                globalIndex++;
            }
        }

        return nums;
    }
}