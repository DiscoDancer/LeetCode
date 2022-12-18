public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var set = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++) {
            if (set.Contains(target - nums[i])) {
                return new int [] {i,Array.IndexOf(nums, target - nums[i]) };
            }
            set.Add(nums[i]);
        }

        return null;
    }
}