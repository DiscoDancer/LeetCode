public class Solution {
    private int[] _candidates;
    private int _target;
    private List<IList<int>> _result = new ();

    // https://leetcode.com/problems/combination-sum/editorial/
    private void F(int remain, List<int> comb, int start) {
        if (remain == 0) {
            _result.Add(comb.ToList());
            return;
        }
        else if (remain < 0) {
            return;
        }

        for (int i = start; i < _candidates.Length; i++) {
            comb.Add(_candidates[i]);
            F(remain - _candidates[i], comb, i);
            comb.RemoveAt(comb.Count() - 1);
        }
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        _candidates = candidates;
        _target = target;
        F(target, new List<int>(), 0);

        return _result;
    }
}