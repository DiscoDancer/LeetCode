public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var table = new Dictionary<int, List<int>>();

        for (int i = 0; i < nums.Length; i++) {
            if (!table.ContainsKey(nums[i])) {
                table[nums[i]] = new ();
            }
            table[nums[i]].Add(i);
        }

        for (int i = 0; i < nums.Length; i++) {
            if (table.ContainsKey(target - nums[i])) {
                foreach (var j in table[target - nums[i]]) {
                    if (i != j) {
                        return new int[] {i,j };
                    }
                }
            }
        }

        return null;
    }
}