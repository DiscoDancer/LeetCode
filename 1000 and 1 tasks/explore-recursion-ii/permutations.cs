public class Solution {
    private List<IList<int>> _result = new ();
    private int[] _nums;

    private void F(List<int> list) {
        if (list.Count() == _nums.Length) {
            _result.Add(list.ToList());
            return;
        }

        foreach (var n in _nums) {
            if (!list.Contains(n)) {
                list.Add(n);
                F(list);
                list.Remove(n);
            }
        }
    }

    public IList<IList<int>> Permute(int[] nums) {
        _nums = nums;
        F(new List<int>(){});

        return _result;
    }
}