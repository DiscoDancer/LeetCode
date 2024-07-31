public class Solution {
    // TL
    public IList<IList<int>> ThreeSum(int[] nums) {
        // хеш таблица, сортировка

        var result = new List<IList<int>>();
        var hs = new HashSet<string>();

        var n = nums.Length;
        for (int i = 0; i < n; i++) {
            for (int j = i+1; j < n; j++) {
                for (int k = j + 1; k < n; k++) {
                    if (nums[i] + nums[j] + nums[k] == 0) {
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