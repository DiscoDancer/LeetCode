public class Solution {
    // super brut n^3
    // positive optimization 2 3 - 2 4 -> 6 -2 4
    // % 2 negative optimization
    // zero case

        private int MaxNoZero(int[] arr)
    {
        int? max = null;
        
        // n*n*n
        for (int start = 0; start < arr.Length; start++)
        {
            for (int size = 1; size <= arr.Length; size++)
            {
                var p = 1;
                var end = start + size - 1; // 0 -> 1
                for (int j = start; j < arr.Length && j <= end; j++)
                {
                    p *= arr[j];
                }

                if (max == null)
                {
                    max = p;
                }
                else
                {
                    max = Math.Max(p, max.Value);
                }
            }
        }

        return max.Value;
    }

    // TL bad
    public int MaxProduct(int[] nums) {
        var split = new List<List<int>>();
        var cur = new List<int>();
        var hasAnyZero = false;
        foreach (var n in nums)
        {
            if (n != 0)
            {
                cur.Add(n);
            }
            else
            {
                hasAnyZero = true;
                split.Add(cur);
                cur = new List<int>();
            }
        }
        split.Add(cur);

        var arrs = split
            .Where(x => x.Count > 1)
            .Select(x => x.ToArray());

        int max = nums.Max();
        foreach (var arr in arrs)
        {
            var res = MaxNoZero(arr);
            max = Math.Max(max, res);
        }
        
        return max;
    }
}