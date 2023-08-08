public class Solution {

    // still TL
    public int MinimumSeconds(IList<int> nums)
    {
        var distinct = nums.Distinct();
        var max = int.MaxValue;
        foreach (var n in distinct)
        {
            var arrMax = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == n)
                {
                    continue;
                }
                
                var r = i;
                var rCount = 0;
                while (nums[r] != n)
                {
                    r++;
                    if (r == nums.Count)
                    {
                        r = 0;
                    }

                    rCount++;
                }
                
                var l = i;
                var lcount = 0;
                while (nums[l] != n)
                {
                    l--;
                    if (l < 0)
                    {
                        l = nums.Count - 1;
                    }

                    lcount++;
                }

                arrMax = Math.Max(arrMax, Math.Min(lcount, rCount));
            }

            max = Math.Min(max, arrMax);
        }

        return max;
    }
}