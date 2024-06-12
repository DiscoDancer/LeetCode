public class Solution {
    // сколько нулей справа и сколько слева
    // prefix sums всякие
    public int[] ProductExceptSelf(int[] nums) {
        var leftTable = new int[nums.Length];

        leftTable[0] = 1;
        for (int i = 1; i < nums.Length; i++) {
            leftTable[i] = leftTable[i-1] *  nums[i-1];
        }

        var acc = 1;
        for (int i = nums.Length-2; i >= 0; i--) {
            acc *= nums[i+1];
            leftTable[i] *= acc;
        }

        return leftTable;
    }
}