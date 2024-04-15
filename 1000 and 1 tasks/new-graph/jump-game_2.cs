public class Solution {
    // больше звучит как dp


    private int[] _nums;

    // смотрит как далеко мы можем зайти через maxDistance
    private bool F(int i, int maxDistance) {
        if (i == _nums.Length - 1) {
            return true;
        }

        maxDistance = Math.Max(maxDistance, i + _nums[i]);
        // можем ли мы идти дальше?
        if (maxDistance > i) {
            return F(i+1, maxDistance);
        }

        return false;
    }

    public bool CanJump(int[] nums) {
        _nums = nums;

        return F(0, 0);
    }
}