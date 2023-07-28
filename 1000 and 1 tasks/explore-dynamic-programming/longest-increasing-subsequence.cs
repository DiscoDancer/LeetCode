public class Solution {
    private int _max = 1;
    private int[] _nums;

    // F
    // текущая точка (index), score

    private void F(int i, int score, int lowBoundary) {
        if (i == _nums.Length) {
            _max = Math.Max(_max, score);
            return;
        }

        // мы можем взять текущий, а можем не взять

        // не берем
        F(i+1, score, lowBoundary);

        // берем
        if (_nums[i] > lowBoundary) {
            F(i+1, score + 1, _nums[i]);
        }
    }

    // TL
    public int LengthOfLIS(int[] nums) {
        _nums = nums;
        F(0,0, int.MinValue);

        return _max;
    }
}