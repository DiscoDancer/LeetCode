public class Solution {
    // запросы [l[i], r[i]]
    // можно в лоб сделать, а потом подумать с формулой
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r) {
                var n = nums.Length;
        var qCount = l.Length;

        var res = new List<bool>();

        for (int i = 0; i < qCount; i++) {
            var a = l[i];
            var b = r[i];

            if (a == b) {
                res.Add(true);
            }
            else {
                var j = a;
                int max = int.MinValue;
                int min = int.MaxValue;
                var hs = new HashSet<int>();
                while (j <= b) {
                    max = Math.Max(nums[j] ,max);
                    min = Math.Min(nums[j] ,min);
                    hs.Add(nums[j]);
                    j++;
                }

                if (hs.Count == 1)
                {
                    res.Add(true);
                    continue;
                }

                var d = (max - min) / (b - a);

                var eq = true;
                for (int x = 0; eq && x <= b - a; x++)
                {
                    var num = min + d * x;
                    eq = hs.Contains(num);
                    if (eq)
                    {
                        hs.Remove(num);
                    }
                }

                eq = eq && !hs.Any();
                res.Add(eq);
            }
        }

        return res;
    }
}