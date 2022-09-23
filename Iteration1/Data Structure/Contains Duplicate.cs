using System.Collections.Generic;

public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        var dic = new Dictionary<int, bool>();
        for (int i = 0; i < nums.Length; i++) {
            if (dic.ContainsKey(nums[i])) {
                return true;
            }
            dic[nums[i]] = true;
        }
        
        return false;
    }
}