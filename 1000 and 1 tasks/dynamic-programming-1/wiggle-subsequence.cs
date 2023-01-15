public class Solution {

    private int WiggleMaxLengthInner(int[] nums, int curIndex, int prev, bool? prevSign, int acc) {
        if (curIndex >= nums.Length) {
            return acc;
        }

        var cur = nums[curIndex];
        var curSign = cur > prev;

        int include = 0;
        int exclude = 0;

        // может взять, можем не взять

        // берем если нету
        if (prevSign == null) {
            include = WiggleMaxLengthInner(nums, curIndex + 1, cur, curSign, acc + 1);
        }
        // берем если другой знак
        else if (prevSign != curSign) {
            include = WiggleMaxLengthInner(nums, curIndex + 1, cur, curSign, acc + 1);
        }

        // не берем
        exclude = WiggleMaxLengthInner(nums, curIndex + 1, prev, prevSign, acc);

        return Math.Max(include, exclude);
    }

    public int WiggleMaxLength(int[] nums) {
        if (nums.Length < 3) {
            return nums.Length;
        }

        return WiggleMaxLengthInner(nums, 1, nums[0], null, 1);
    }
}