public class Solution {
    private int[] _nums;
    private int _target;
    private int _total;
    private Dictionary<(int, int), int> _mem = new ();

    private int F(int i, int sum) {
        if (i == _nums.Length) {
            return sum == _target ? 1 : 0;
        } 
        else {
            if (_mem.ContainsKey((i,sum + _total))) {
                return _mem[(i, sum + _total)];
            }
            var a = F(i + 1, sum + _nums[i]);
            var b = F(i+1, sum - _nums[i]);

            _mem[(i, sum + _total)] = a + b;
            return _mem[(i, sum + _total)];
        }
    }

    public int FindTargetSumWays(int[] nums, int target) {
        _nums = nums;
        _target = target;
        _total = _nums.Sum();

        return F(0, 0);
    }
}