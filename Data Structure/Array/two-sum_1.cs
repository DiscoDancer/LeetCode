using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        
        var dic = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++) {
            if (!dic.ContainsKey(nums[i])) {
                dic[nums[i]] = i;
            }
        }
        
        for (int i = 0; i < nums.Length; i++) {
            var diff = target - nums[i];
            
            if (dic.ContainsKey(diff)) {
                var pairIndex = dic[diff];
                
                if (pairIndex == i) {
                    continue;
                }
                
                if (i < pairIndex) {
                    return new int [] {i, pairIndex};
                }
                return new int [] {pairIndex, i};
            }
        }
        
        return null;
    }
}