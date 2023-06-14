public class Solution {

    // editorial 
    private int[] _nums;
    private int _target;
    private Dictionary<(int, int), int> _mem = new ();

    private int F(int i, int sum) {
        if (i == _nums.Length) {
            return sum == _target ? 1 : 0;
        } 
        else {
            if (_mem.ContainsKey((i,sum))) {
                return _mem[(i, sum)];
            }
            var a = F(i + 1, sum + _nums[i]);
            var b = F(i+1, sum - _nums[i]);

            _mem[(i, sum)] = a + b;
            return _mem[(i, sum)];
        }
    }

    public int FindTargetSumWays(int[] nums, int target) {
        _nums = nums;
        _target = target;

        return F(0, 0);
    }
}