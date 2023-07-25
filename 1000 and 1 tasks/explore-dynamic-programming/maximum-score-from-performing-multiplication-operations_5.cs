public class Solution {
    private int[] _multipliers;
    private int[] _nums;

    private int F(int numsL, int numsR, int multiIndex) {
        if (multiIndex == _multipliers.Length) {
            return 0;
        }

        // берем сначала
        var firstNum = _nums[numsL];
        var a = firstNum * _multipliers[multiIndex];
        var leftResult = F(numsL+1, numsR, multiIndex+1) + a;
        

        // берем с конца
        var lastNum = _nums[numsR];
        var b = lastNum * _multipliers[multiIndex];
        var rightResult = F(numsL, numsR -1,  multiIndex+1) + b;

        return Math.Max(leftResult, rightResult);
    }

    public int MaximumScore(int[] nums, int[] multipliers) {
        _multipliers = multipliers;
        _nums = nums;

        return F(0, _nums.Length-1, 0);
    }
}