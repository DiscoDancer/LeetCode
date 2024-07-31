public class Solution {
    // что даст сортировка nlog, я смогу за n отвечать, есть ли сумма 2х = x
    // то есть я могу сделать nnlog

    // по просто хеш таблица сумм выглядит по-лучше n*n
    public IList<IList<int>> ThreeSum(int[] nums) {
        // хеш таблица, сортировка

        var result = new List<IList<int>>();

        var table = new Dictionary<int, List<List<int>>>();

        var n = nums.Length;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                var sum = nums[i] + nums[j];
                if (!table.ContainsKey(sum)) {
                    table[sum] = new ();
                }
                table[sum].Add(new List<int>() {i,j});
            }
        }

        var hs = new HashSet<string>();
        for (int i = 0; i < n; i++) {
            if (table.ContainsKey(-nums[i])) {
                foreach (var jk in table[-nums[i]]) {
                    if (!jk.Contains(i)) {
                        var j = jk[0];
                        var k = jk[1];
                        var k1 = new List<int>() {
                            nums[i],
                            nums[j],
                            nums[k]
                        };
                        k1.Sort();
                        var key = string.Join("", k1);
                        if (hs.Add(key)) {
                            result.Add(k1);
                        }
                    }
                }
            }
        }

        return result;
    }
}