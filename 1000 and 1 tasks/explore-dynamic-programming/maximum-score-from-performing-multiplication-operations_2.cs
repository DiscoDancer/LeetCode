public class Solution {
    // множители идут подряд, а числа читаем либо с конца либо сначала

    private int _max = int.MinValue;
    private int[] _multipliers;

    // replace to int return type
    // replace nums to int
    private void F(List<int> nums, int multiIndex, int sum) {
        if (multiIndex == _multipliers.Length) {
            _max = Math.Max(_max, sum);
            return;
        }

        // берем сначала
        var firstNum = nums.First();
        var a = firstNum * _multipliers[multiIndex];
        nums.RemoveAt(0);
        F(nums, multiIndex+1, sum + a);
        nums.Insert(0, firstNum);

        // берем с конца
        var lastNum = nums.Last();
        var b = lastNum * _multipliers[multiIndex];
        nums.RemoveAt(nums.Count()-1);
        F(nums, multiIndex+1, sum + b);
        nums.Add(lastNum);
    }

    public int MaximumScore(int[] nums, int[] multipliers) {
        var readBegin = nums.ToList();
        var readEnd = nums.ToList();

        _multipliers = multipliers;

        F(nums.ToList(), 0, 0);

        return _max;
    }
}