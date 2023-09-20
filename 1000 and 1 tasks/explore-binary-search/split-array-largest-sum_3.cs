public class Solution {

    private int[] _nums;
    private int _k;

    // всего 2 варианта - ставим или не ставим точку
    private int F(int index, int accSum, int breakCount, int max) {
        if (index == _nums.Length)
        {
            if (breakCount == _k - 1)
            {
                return max;
            }
            
            return int.MaxValue;
        }
        
        // копим дальше
        var keep = F(index + 1, accSum + _nums[index], breakCount, Math.Max(max, accSum + _nums[index]));
        var putBreak = int.MaxValue;
        
        // ставим точку (текущий последний в сете)
        if (breakCount < _k - 1 && index < _nums.Length - 1)
        {
            putBreak = F(index + 1, 0, breakCount + 1, Math.Max(max, accSum + _nums[index])); 
        }

        return Math.Min(keep, putBreak);
    }


    public int SplitArray(int[] nums, int k) {
        _nums = nums;
        _k = k;
        
        return F(0, 0, 0, 0);
    }
}