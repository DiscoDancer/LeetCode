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
                var queue = new PriorityQueue<int, int>();
                var j = a;
                while (j <= b) {
                    queue.Enqueue(nums[j], nums[j]);
                    j++;
                }

                var eq = true;
                queue.TryDequeue(out var v1, out var k1);
                queue.TryDequeue(out var v2, out var k2);
                int diff = v1 - v2;
                int prev = v2;

                while (eq && queue.TryDequeue(out var v, out var k)) {
                    var curDiff = prev - v;
                    eq = diff == curDiff;
                    prev = v;
                }

                res.Add(eq);
            }
        }

        return res;
    }
}