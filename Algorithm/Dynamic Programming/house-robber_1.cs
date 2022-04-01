public class Solution {
    public int Rob(int[] nums) {
        var n = nums.Length;
        var D = new int[n];
        
        for (int i = 0; i < n; i++) {
            if (i == 0 || i == 1) {
                D[i] = nums[i];
            }
            else if (i == 2) {
                D[i] = nums[i] + nums[i-2];
            }
            else {
                D[i] = Math.Max(D[i-2], D[i - 3]) + nums[i];
            }
        }
        return D.Max();
    }
}