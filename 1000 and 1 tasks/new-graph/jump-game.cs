public class Solution {
    // больше звучит как dp


    private int[] _nums;

    private bool F(int i) {
        if (i >= _nums.Length ) {
            return false;
        }
        if (i == _nums.Length - 1) {
            return true;
        }

        var result = false;

        for (int j = 1; j <= _nums[i]; j++) {
            result = result || F(i+j);
        }

        return result;
    }

    public bool CanJump(int[] nums) {
        _nums = nums;

        return F(0);
    }
}