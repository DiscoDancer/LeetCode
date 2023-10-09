public class Solution {
    // префиксные произведения
    public int[] ProductExceptSelf(int[] nums) {
        var arr1 = new int[nums.Length];
        arr1[0] = 1;
        for (int i = 1; i < nums.Length; i++) {
            arr1[i] = arr1[i-1] * nums[i-1];
        }

        var arr2 = new int[nums.Length];
        arr2[arr2.Length - 1] = 1;
        for (int i = arr2.Length - 2; i >= 0; i--) {
            arr2[i] = arr2[i+1] * nums[i+1];
        }

        var result = new int[nums.Length];
        for (int i = 0; i < result.Length; i++) {
            result[i] = arr1[i] * arr2[i];
        }

        return result;
    }
}