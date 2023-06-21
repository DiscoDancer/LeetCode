public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        var dictionary = new Dictionary<int, List<int>>();
        for (var i = 0; i < nums.Length; i++) {
            if (!dictionary.ContainsKey(nums[i])) {
                dictionary[nums[i]] = new List<int>();
            }
            dictionary[nums[i]].Add(i);
        }

        for (int i = 0; i < nums.Length; i++) {
            var diff = target - nums[i];
            if (dictionary.ContainsKey(diff)) {
                foreach (var index in dictionary[diff]) {
                    if (index != i) {
                        return new int[] {i, index};
                    }
                }
            }
        }

        return null;
    }
}