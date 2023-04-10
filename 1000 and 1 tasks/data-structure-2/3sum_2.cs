public class Solution {
    // https://leetcode.com/problems/3sum/submissions/

    private int[] _nums;
    private IList<IList<int>> _result = new List<IList<int>>();

    public IList<IList<int>> ThreeSum(int[] nums) {
        _nums = nums.OrderBy(x => x).ToArray();

        for (int i = 0; i < _nums.Length && _nums[i] <= 0; i++) {
            if (i == 0 || _nums[i - 1] != _nums[i] ) {
                TwoSumII(i);
            }
        }

        return _result;
    }

    private void TwoSumII(int i) {
        int lo = i + 1, hi = _nums.Length - 1;
        while (lo < hi) {
            int sum = _nums[i] + _nums[lo] + _nums[hi];
            if (sum < 0) {
                ++lo;
            } else if (sum > 0) {
                --hi;
            } else {
                _result.Add(new List<int>() {_nums[i], _nums[lo++], _nums[hi--]});
                while (lo < hi && _nums[lo] == _nums[lo - 1])
                    ++lo;
            }
        }
    }
}