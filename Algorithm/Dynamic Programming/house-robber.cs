public class Solution {
    public int Rob(int[] nums) {
        var n = nums.Length;
        var D = new int[n];
        
        for (int i = 0; i < n; i++) {
            D[i] = nums[i];
            
            int max = 0;
            for (int j = 0; j < i - 1; j++) {
                if (D[j] > max) {
                    max = D[j];
                }
            }
            if (D[i] < max + D[i]) {
                D[i] = max + D[i];
            }
        }
        
        return D.Max();
    }
}