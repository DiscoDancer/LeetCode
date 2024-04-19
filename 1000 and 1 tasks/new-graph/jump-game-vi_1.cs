
// TL
public class Solution {
    private int[] _nums;
    private int _k;

    private int F(int index, int sum) {
        if (index == _nums.Length) {
            return sum;
        }

        var max = int.MinValue;

        for (int i = 1; i <= _k && index + i <= _nums.Length ; i++) {
            max = Math.Max(max,  F(index + i, sum + _nums[index]));
        }

        return max;
    }

    public int MaxResult(int[] nums, int k) {
        _nums = nums;
        _k = k;

        return F(0,0);
    }
}