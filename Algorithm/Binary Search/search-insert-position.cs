using System.Linq;

public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int L = 0;
        int R = nums.Length - 1;
        int M = -1;

        while (L <= R)
        {
            M = L + (R - L) / 2;
            if (nums[M] == target)
            {
                return M;
            }
            if (nums[M] > target)
            {
                R = M - 1;
                
            }
            else
            {
                L = M + 1;
            }
        }
        
        if (R < M) return M;
        if (L > M) return M + 1;

        return -1;
    }
}