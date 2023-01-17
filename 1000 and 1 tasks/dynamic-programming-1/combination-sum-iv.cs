public class Solution {
    public int CombinationSum4(int[] nums, int target) {
        var table = new int[target + 1];

        var min = Math.Min(nums.Min(), target);

        for (int i = min; i <= target; i++) {
            foreach (var num in nums) {
                var diff = i - num;
                if (diff > 0) {
                    table[i] += table[diff];
                }
                else if (diff == 0) {
                    table[i] += 1; 
                }
            }
        }

        return table[target];
    }
}