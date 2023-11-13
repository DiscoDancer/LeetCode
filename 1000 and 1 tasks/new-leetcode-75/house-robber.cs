public class Solution {
    private int _max = 0;
    private int[] _nums;

    private void F(int index, bool canRobe, int acc) {
        if (index == _nums.Length) {
            _max = Math.Max(_max, acc);
            return;
        }

        // robe
        if (canRobe) {
            F(index + 1, false, acc + _nums[index]);
        }

        // not to robe
        F(index + 1, true, acc);
    }

    // TL
    public int Rob(int[] nums) {
        _nums = nums;

        F(0, true, 0);

        return _max;
    }
}