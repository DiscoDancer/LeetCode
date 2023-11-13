public class Solution {
    private int[] _nums;

    private int F(int index, bool canRobe) {
        if (index == _nums.Length) {
            return 0;
        }

        var notRobeResult = F(index + 1, true);
        if (canRobe) {
            var robeResult = _nums[index] + F(index + 1, false);
            return Math.Max(notRobeResult, robeResult);
        }

        return notRobeResult;
    }


    // still TL
    public int Rob(int[] nums) {
        _nums = nums;

        return F(0, true);
    }
}