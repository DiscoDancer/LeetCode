public class Solution {
    // множители идут подряд, а числа читаем либо с конца либо сначала

    private int _max = int.MinValue;
    private int[] _multipliers;
    private int[] _nums;

    // replace to int
    // L R
    private int F(int numsL, int numsR, int multiIndex, int sum) {
        if (multiIndex == _multipliers.Length) {
            return sum;
        }

        // берем сначала
        var firstNum = _nums[numsL];
        var a = firstNum * _multipliers[multiIndex];
        var leftResult = F(numsL+1, numsR, multiIndex+1, sum + a);
        

        // берем с конца
        var lastNum = _nums[numsR];
        var b = lastNum * _multipliers[multiIndex];
        var rightResult = F(numsL, numsR -1,  multiIndex+1, sum + b);

        return Math.Max(leftResult, rightResult);
    }

    public int MaximumScore(int[] nums, int[] multipliers) {
        _multipliers = multipliers;
        _nums = nums;

        return F(0, _nums.Length-1, 0, 0);
    }
}