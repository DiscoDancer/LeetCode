public class Solution {
    private List<IList<int>> _result = new ();
    private int _k;
    private int _n;

    // нужен ествественный сдвиг

    private void F(List<int> nums, int sum) {
        if (nums.Count() == _k) {
            if (sum == _n) {
                _result.Add(nums.ToList());
            }
            return;
        }

        var start = nums.LastOrDefault();
        start++;


        for (int i = start; i <= 9; i++) {
            if (sum + i <= _n) {
                nums.Add(i);
                F(nums, sum + i);
                nums.RemoveAt(nums.Count()-1);
            }
            else {
                break;
            }
        }
    }

    public IList<IList<int>> CombinationSum3(int k, int n) {
        _k = k;
        _n = n;

        F(new List<int>{}, 0);


        return _result;
    }
}