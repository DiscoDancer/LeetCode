public class Solution {
    // сколько нулей справа и сколько слева
    // prefix sums всякие
    public int[] ProductExceptSelf(int[] nums) {
        var leftTable = new int[nums.Length];
        var rightTable = new int[nums.Length];

        leftTable[0] = 1;
        for (int i = 1; i < nums.Length; i++) {
            leftTable[i] = leftTable[i-1] *  nums[i-1];
        }

        rightTable[nums.Length-1] = 1;
        for (int i = nums.Length-2; i >= 0; i--) {
            rightTable[i] = rightTable[i+1]*nums[i+1];
        }

        var result = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++) {
            result[i] = leftTable[i]*rightTable[i];
        }

        return result;
    }
}