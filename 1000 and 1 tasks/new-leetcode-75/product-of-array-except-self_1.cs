public class Solution {
    // префиксные произведения
    public int[] ProductExceptSelf(int[] nums) {
        var arr1 = new int[nums.Length];
        arr1[0] = 1;
        for (int i = 1; i < nums.Length; i++) {
            arr1[i] = arr1[i-1] * nums[i-1];
        }
        
        var acc = 1;
        for (int i = arr1.Length - 2; i >= 0; i--) {
            acc *= nums[i+1];
            arr1[i] *= acc;
        }

        return arr1;
    }
}