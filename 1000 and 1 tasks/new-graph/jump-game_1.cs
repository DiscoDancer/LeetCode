public class Solution {
    // больше звучит как dp


    private int[] _nums;
    private bool?[] _mem;

    private bool F(int i) {
        if (i >= _nums.Length ) {
            return false;
        }
        if (i == _nums.Length - 1) {
            return true;
        }
        if (_mem[i] != null) {
            return _mem[i].Value;
        }

        var result = false;

        for (int j = 1; j <= _nums[i] && !result; j++) {
            result = result || F(i+j);
        }

        _mem[i] = result;
        return result;
    }

    public bool CanJump(int[] nums) {
        _nums = nums;
        _mem = new bool?[_nums.Length];

        return F(0);
    }
}