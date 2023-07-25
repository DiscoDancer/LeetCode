public class Solution {
    // множители идут подряд, а числа читаем либо с конца либо сначала

    private int _max = int.MinValue;

    private void F(List<int> nums, List<int> multi, int sum) {
        if (!multi.Any()) {
            _max = Math.Max(_max, sum);
            return;
        }

        var curMulti = multi[0];
        var copyMulty = multi.ToList();
        copyMulty.RemoveAt(0);

        // берем сначала
        var a = nums.First() * curMulti;
        var copyNums = nums.ToList();
        copyNums.RemoveAt(0);
        F(copyNums, copyMulty, sum + a);

        // берем с конца
        var b = nums.Last() * curMulti;
        var copyNums2 = nums.ToList();
        copyNums2.RemoveAt(copyNums2.Count()-1);
        F(copyNums2, copyMulty.ToList(), sum + b);
    }

    // TL
    public int MaximumScore(int[] nums, int[] multipliers) {
        var readBegin = nums.ToList();
        var readEnd = nums.ToList();
        var multi =  multipliers.ToList();

        F(nums.ToList(), multipliers.ToList(), 0);

        return _max;
    }
}