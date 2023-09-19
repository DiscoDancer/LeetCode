public class Solution {
    private int[] _nums;
    private int _k;
    private int _min = int.MaxValue;

    // всего 2 варианта - ставим или не ставим точку
    private void F(int index, int accSum, int breakCount, int max) {
        if (index == _nums.Length)
        {
            if (breakCount == _k - 1)
            {
                _min = Math.Min(max, _min);
            }
            return;
        }
        
        // копим дальше
        F(index + 1, accSum + _nums[index], breakCount, Math.Max(max, accSum + _nums[index]));
        
        // ставим точку (текущий последний в сете)
        if (index == _nums.Length - 1)
        {
            F(index + 1, 0, breakCount, Math.Max(max, accSum + _nums[index]));
        }
        else
        {
            F(index + 1, 0, breakCount + 1, Math.Max(max, accSum + _nums[index])); 
        }

    }

    // TL

    public int SplitArray(int[] nums, int k) {
        _nums = nums;
        _k = k;
        

        F(0, 0, 0, 0);

        return _min;
    }
}