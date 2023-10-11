public class Solution {
    // попробовать dp

    private int[] _nums;
    private int _max = 0;

    private void F(int i, int k, int score) {
        if (i == _nums.Length) {
            _max = Math.Max(_max, score);
            return;
        }

        if (_nums[i] == 0) {
            if (k > 0) {
                // use k
                F(i+1, k-1, score + 1);
            }
            // reset score
            _max = Math.Max(_max, score);
            F(i+1, k, 0);
        }
        else {
            F(i+1, k, score + 1);
        }
    }

    // TL
    public int LongestOnes(int[] nums, int k) {
        _nums = nums;

        F(0, k, 0);

        return _max;
    }
}