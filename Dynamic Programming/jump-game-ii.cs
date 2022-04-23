public class Solution {
    public int Jump(int[] nums) {        
        var statuses = new int[nums.Length];
        
        statuses[0] = 0;
        for (int i = 1; i < nums.Length; i++) {
            statuses[i] = int.MaxValue;
        }
        
        for (int i = 0; i < nums.Length; i++) {
            if (i == 0 || statuses[i] > 0) {
                for (int j = i + 1; j < i + 1 + nums[i] && j < nums.Length; j++) {
                    statuses[j] = Math.Min(statuses[i] + 1, statuses[j]);
                }
            }
        }
        
        return statuses[nums.Length - 1];
    }
}