public class Solution {

    private int[] _nums;
    private Dictionary<(int n, int s), bool> _cache = new ();

    // https://leetcode.com/problems/partition-equal-subset-sum/editorial/

    // суть в том, что нам достаточно найти только 1 половину, вторая = все остальное, поэтому ниже ||
    private bool F(int n, int subSetSum) {
        if (subSetSum == 0) {
            return true;
        }
        if (n == 0 || subSetSum < 0) {
            return false;
        }
        if (_cache.ContainsKey((n, subSetSum))) {
            return _cache[(n, subSetSum)];
        }

        var result = F(n - 1, subSetSum - _nums[n-1]) || F(n - 1, subSetSum);
        _cache[(n, subSetSum)] = result;
        return result;
    }

    public bool CanPartition(int[] nums) {
        var sum = nums.Sum();

        if (sum % 2 == 1) {
            return false;
        }

        _nums = nums;

        return F(nums.Length - 1, sum / 2);
    }
}