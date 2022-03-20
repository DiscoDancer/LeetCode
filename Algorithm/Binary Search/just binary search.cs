using System.Linq;

public class Solution {
    public int Search(int[] nums, int target) {
        if (nums.Length == 0) {
            return -1;
        }
        
        int N = nums.Length;
        int L = 0;
        int R = N - 1;
        
        while (L <= R) {
            int M = (L + R) / 2;
            if (nums[M] == target) {
                return M;
            }
            if (nums[M] > target) {
                R = M - 1;
            }
            else {
                L = M + 1;
            }
        }
        
        return -1;
    }
}