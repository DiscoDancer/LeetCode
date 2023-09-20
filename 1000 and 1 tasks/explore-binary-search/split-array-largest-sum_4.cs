public class Solution {

    private int[] _nums;
    private int[] _prefixSums;

    // всего 2 варианта - ставим или не ставим точку
    private int F(int index, int breaksRemaining) {

        if (breaksRemaining == 1)
        {
            return _prefixSums[_nums.Length] - _prefixSums[index];
        }

        var minimumLargestSplitSum = int.MaxValue;
        for (int i = index; i <= _nums.Length - breaksRemaining; i++)
        {
            var firstSplitSum = _prefixSums[i + 1] - _prefixSums[index];

            var largestSplitSum = Math.Max(firstSplitSum, F(i + 1, breaksRemaining - 1));

            minimumLargestSplitSum = Math.Min(minimumLargestSplitSum, largestSplitSum);
            
            if (firstSplitSum >= minimumLargestSplitSum) {
                break;
            }
        }

        return minimumLargestSplitSum;
    }

    // editorial
    public int SplitArray(int[] nums, int k) {
        _nums = nums;

        _prefixSums = new int[nums.Length + 1];
        for (int i = 0; i < nums.Length ; i++) {
            _prefixSums[i + 1] = _prefixSums[i] + nums[i];
        }
        
        return F(0, k);
    }
}