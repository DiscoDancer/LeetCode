
// TL
public class Solution {
    private int[] _nums;
    private int _k;

    private int F(int index) {
        if (index == _nums.Length) {
            return 0;
        }

        var max = int.MinValue;

        for (int i = 1; i <= _k && index + i <= _nums.Length ; i++) {
            max = Math.Max(max,  F(index + i));
        }

        return _nums[index] + max;
    }

    public int MaxResult(int[] nums, int k) {
        _nums = nums;
        _k = k;

        return F(0);
    }
}