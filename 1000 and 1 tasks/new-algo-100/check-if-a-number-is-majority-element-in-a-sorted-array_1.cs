public class Solution {


    // мб понятнее было бы сразу L и R отдавать и все случаи расписать
    // но немного читов

   private int[] _nums;

    private long FindLastLowerOrDefault(long x) {
        long L = 0;
        long R = _nums.Length - 1;

        while (L <= R) {
            long M = L + (R-L)/2;

            if (_nums[M] < x && (M == _nums.Length - 1 || _nums[M+1] >= x)) {
                return M;
            }
            else if (_nums[M] < x) {
                L = M + 1;
            }
            else {
                R = M - 1;
            }
        }

        return -1;
    }
    
    private long FindFirstHigherOrDefault(long x) {
        long L = 0;
        long R = _nums.Length - 1;

        while (L <= R) {
            var M = L + (R-L)/2;

            if (_nums[M] > x && (M == 0 || _nums[M - 1] <= x))
            {
                return M;
            }
            else if (_nums[M] <= x)
            {
                L = M + 1;
            }
            else {
                R = M - 1;
            }
        }

        return -1;
    }

    public bool IsMajorityElement(int[] nums, int target) {
        _nums = nums;

        var firstLowerIndex = FindLastLowerOrDefault(target);
        var firstHigherIndex = FindFirstHigherOrDefault(target);

        // они либо одинаковые, либо его вообще там нету
        // хотя в этом я не уверен, но в любом случае это работает
        if (firstLowerIndex == -1 && firstHigherIndex == -1)
        {
            return nums[0] == target;
        }
        // фикс для следующей проверки
        if (firstLowerIndex != -1 && firstHigherIndex == -1)
        {
            firstHigherIndex = nums.Length;
        }
        // самый обычный случай
        if (firstLowerIndex != -1 && firstHigherIndex != -1)
        {
            
            return (firstHigherIndex - 1) - (firstLowerIndex + 1) + 1 > nums.Length / 2;
        }
        
        return false;
    }
}