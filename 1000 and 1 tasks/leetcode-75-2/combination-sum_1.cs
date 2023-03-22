public class Solution {
    private List<IList<int>> _result = new ();
    private HashSet<string> _hs = new ();
    private int[] _candidates;
    private int _target;

    private void AddToResult(int[] nums) {
        var sb = new StringBuilder();
        foreach (var n in nums) {
            sb.Append(n);
        }
        if (_hs.Add(sb.ToString())) {
            _result.Add(Convert(nums));
        }
    }

    private List<int> Convert(int[] nums) {
        var list = new List<int>();
        for (int i = 0; i < nums.Length; i++) {
            while (nums[i] > 0) {
                list.Add(_candidates[i]);
                nums[i]--;
            }
        }

        return list;
    }

    private void F(int[] nums, int sum) {
            for (var i = 0; i < _candidates.Length; i++) {
                var candidate = _candidates[i];
                if (candidate + sum > _target) {
                    continue;
                }
                var copy = nums.ToArray();
                copy[i]++;
                if (candidate + sum == _target) {
                    AddToResult(copy);
                }
                else {
                    F(copy, candidate + sum);
                }
            }
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        _candidates = candidates;
        _target = target;

        F(new int[candidates.Length], 0);

        return _result;
    }
}