public class Solution {
    // TL
    public int MinimumSeconds(IList<int> nums)
    {
        var distinct = nums.Distinct();
        var max = int.MaxValue;
        foreach (var n in distinct)
        {
            var arr = new int[nums.Count];
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == n)
                {
                    arr[i] = 0;
                }
                else
                {
                    // нужно найти минимальное расстояние до n
                    var minDistToN = int.MaxValue;
                    
                    
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
                    minDistToN = Math.Min(rCount, minDistToN);

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
                    minDistToN = Math.Min(lcount, minDistToN);

                    arr[i] = minDistToN;
                }
            }

            max = Math.Min(max, arr.Max());
        }

        return max;
    }
}