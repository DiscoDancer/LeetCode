
// TL
public class Solution {
    private int[] _nums;
    private int _k;

    private int _max = 0;

    private void F(int index, int sum) {
        if (index == _nums.Length) {
            _max = Math.Max(_max, sum);
        }

        for (int i = 1; i <= _k && index + i <= _nums.Length ; i++) {
            F(index + i, sum + _nums[index]);
        }
    }

    public int MaxResult(int[] nums, int k) {
        _nums = nums;
        _k = k;

        F(0,0);
        
        return _max;
    }
}