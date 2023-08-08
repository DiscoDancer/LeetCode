public class Solution {
    // editorial https://leetcode.com/problems/minimum-seconds-to-equalize-a-circular-array/submissions/
    public int MinimumSeconds(IList<int> nums) {
        var dictionary = new Dictionary<int, List<int>>();

        for (int i = 0; i < nums.Count(); i++) {
            if (!dictionary.ContainsKey(nums[i])) {
                dictionary[nums[i]] = new ();
            }
            dictionary[nums[i]].Add(i);
        }

        var globalMax = int.MaxValue;
        foreach (var k in dictionary.Keys) {
            var indexes = dictionary[k];
            indexes.Add(indexes.First() + nums.Count());

            var max = 0;
            for (int i = 1; i < indexes.Count(); i++) {
                max = Math.Max(max, (indexes[i] - indexes[i-1])/2);
            }

            globalMax = Math.Min(globalMax, max);
        }

        return globalMax;
    }
}