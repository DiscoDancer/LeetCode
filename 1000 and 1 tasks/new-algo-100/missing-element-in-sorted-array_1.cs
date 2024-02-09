public class Solution {
    private int FindIntervalIndex(int[] nums, int k)
    {
        var intervalCount = nums.Length - 1;
        
        var L = 0;
        var R = intervalCount - 1;
        while (L <= R)
        {
            var M = L + (R - L) / 2;
            var m_start = nums[M];
            var m_end = nums[M + 1];
            var m_missing_count = m_end - m_start - 1;
            
            // сколько слева?
            var left_start = nums[0];
            var left_end = m_start;
            var left_missing_count = (left_end - left_start + 1) - (M + 1);
            
            // идем влево?
            if (k <= left_missing_count)
            {
                R = M - 1;
            }
            // идем вправо
            else if (k > left_missing_count + m_missing_count)
            {
                L = M + 1;
            }
            // ответ в M
            else
            {
                k -= left_missing_count;
                return m_start + k;
            }

        }

        var realCount = nums.Length;
        var expectedCount = nums.Last() - nums.First() + 1;
        var missingCount = expectedCount - realCount;

        k -= missingCount;
        
        return nums.Last() + k;
    }
    
    public int MissingElement(int[] nums, int k)
    {
        var resultOrDefault = FindIntervalIndex(nums, k);
        
        return resultOrDefault;
    }
}