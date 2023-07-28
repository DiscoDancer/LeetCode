public class Solution {
    private int[] _nums;

    private int F(int i, int lowBoundary) {
        if (i == _nums.Length) {
            return 0;
        }

        // берем
        if (_nums[i] > lowBoundary) {
            return Math.Max(F(i+1, lowBoundary), 1 + F(i+1, _nums[i]));
        }

        return F(i+1, lowBoundary);
    }

    public int LengthOfLIS(int[] nums) {
        _nums = nums;

        return F(0, int.MinValue);
    }
}