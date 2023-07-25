public class Solution {
    // множители идут подряд, а числа читаем либо с конца либо сначала

    private int _max = int.MinValue;
    private int[] _multipliers;

    // replace to int
    private void F(List<int> nums, int multiIndex, int sum) {
        if (multiIndex == _multipliers.Length) {
            _max = Math.Max(_max, sum);
            return;
        }

        // берем сначала
        var a = nums.First() * _multipliers[multiIndex];
        var copyNums = nums.ToList();
        copyNums.RemoveAt(0);
        F(copyNums, multiIndex+1, sum + a);

        // берем с конца
        var b = nums.Last() * _multipliers[multiIndex];
        var copyNums2 = nums.ToList();
        copyNums2.RemoveAt(copyNums2.Count()-1);
        F(copyNums2, multiIndex+1, sum + b);
    }

    public int MaximumScore(int[] nums, int[] multipliers) {
        var readBegin = nums.ToList();
        var readEnd = nums.ToList();

        _multipliers = multipliers;

        F(nums.ToList(), 0, 0);

        return _max;
    }
}