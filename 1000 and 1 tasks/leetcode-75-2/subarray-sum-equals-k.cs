public class Solution {
    // https://leetcode.com/problems/path-sum-iii/editorial/
    public int SubarraySum(int[] nums, int k) {
        var dictionary = new Dictionary<int, int>();
        var sum = 0;
        var count = 0;
        foreach (var n in nums) {
            sum += n;
            if (sum == k) {
                count ++;
            }

            if (dictionary.ContainsKey(sum - k)) {
                count += dictionary[sum - k];
            }

            if (dictionary.ContainsKey(sum)) {
                dictionary[sum]++;
            }
            else {
                dictionary[sum] = 1;
            }
        }

        return count;
    }
}