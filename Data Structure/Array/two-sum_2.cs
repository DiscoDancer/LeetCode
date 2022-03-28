using System.Collections.Generic;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        
        var dic = new Dictionary<int, int>();
        
        for (int i = 0; i < nums.Length; i++) {
            var diff = target - nums[i];
            
            if (dic.ContainsKey(diff)) {
                return new int [] {dic[diff], i};
            }
            else {
                dic[nums[i]] = i;
            }
        }
        
        return null;
    }
}