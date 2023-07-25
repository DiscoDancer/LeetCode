public class Solution {
    private int[] _multipliers;
    private int[] _nums;
    private Dictionary<(int,int), int> _mem = new ();

    // editorial optimization with calculation of right
    private int F(int numsL, int multiIndex) {
        if (multiIndex == _multipliers.Length) {
            return 0;
        }
        if (_mem.ContainsKey((numsL, multiIndex))) {
            return _mem[(numsL, multiIndex)];
        }

        var numsR = _nums.Length - 1 - (multiIndex-numsL);

        // берем сначала
        var firstNum = _nums[numsL];
        var a = firstNum * _multipliers[multiIndex];
        var leftResult = F(numsL+1, multiIndex+1) + a;
        

        // берем с конца
        var lastNum = _nums[numsR];
        var b = lastNum * _multipliers[multiIndex];
        var rightResult = F(numsL, multiIndex+1) + b;

        _mem[(numsL, multiIndex)] = Math.Max(leftResult, rightResult);

        return _mem[(numsL, multiIndex)];
    }

    public int MaximumScore(int[] nums, int[] multipliers) {
        _multipliers = multipliers;
        _nums = nums;

        return F(0, 0);
    }
}