public class Solution {
    
    public int Find(int[] nums, int target) {
        int L = 0;
        int R = nums.Length;
        
        while (L < R) {
            int M = L + (R-L)/2;
            if (nums[M] == target) {
                return M;
            }
            if (nums[M] > target) {
                R = M - 1;
            } else {
                L = M + 1;
            }
        }
        
        return -1;
    }
    
    public int Find2(int[] nums, int target) {
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == target) {
                return i;
            }
        }
        
        return -1;
    }
    
    
    public int[] TwoSum(int[] nums, int target) {
        
        var diffs = nums
            .Select(x => target - x)
            .ToArray();
        
        var sortedNums = nums.OrderBy(x => x).ToArray();
        
        for (int i = 0; i < diffs.Length; i++) {
            var diff = diffs[i];
            var hasPair = Find(sortedNums, diff) != -1;
            var pairIndex = Find2(nums, diff);
            if (pairIndex != -1 && i != pairIndex) {
                if (i < pairIndex) {
                    return new [] {i, pairIndex};
                }
                return new [] {pairIndex, i};
            }
            
        }
        
        return null;
    }
}