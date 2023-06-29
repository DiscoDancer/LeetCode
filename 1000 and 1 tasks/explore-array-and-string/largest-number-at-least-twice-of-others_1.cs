public class Solution {

    public int DominantIndex(int[] nums) {
        var max = -1;
        var maxIndex = -1;
        var max2 = -1;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] > max) {
                max2 = max;
                max = nums[i];
                maxIndex = i;
            }
            else if (nums[i] > max2) {
                max2 = nums[i];
            }
        }

        return max >= max2*2 ? maxIndex : -1;
    }
}