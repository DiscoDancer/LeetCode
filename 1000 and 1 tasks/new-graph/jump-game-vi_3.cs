
// stack overflow, кек
// до этого было неправильно
public class Solution {
    private int[] _nums;
    private int _k;
    private long?[] _mem;

    private long F(int index) {
        if (index == _nums.Length - 1) {
            return _nums[index];
        }
        if (_mem[index] != null) {
            return _mem[index].Value;
        }

        long max = long.MinValue;

        for (int i = 1; i <= _k && index + i < _nums.Length ; i++) {
            max = Math.Max(max,  F(index + i));
        }

        _mem[index]  = _nums[index] + max;
        return _mem[index].Value;
    }

    public int MaxResult(int[] nums, int k) {
        _nums = nums;
        _k = k;
        _mem = new long?[nums.Length];

        return (int)F(0);
    }
}