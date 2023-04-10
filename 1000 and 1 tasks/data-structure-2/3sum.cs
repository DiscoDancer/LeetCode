public class Solution {
    // n3
    // n2 (sums + ht)

    // TL
    public IList<IList<int>> ThreeSum(int[] nums) {
        nums = nums.OrderBy(x => x).ToArray();
        var hs = new Dictionary<string, IList<int>>();
        var result = new List<IList<int>>();

        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                for (int k = j + 1; k < nums.Length; k++) {
                    if (nums[i] + nums[j] + nums[k] == 0) {
                        var str = "" + nums[i] + nums[j] + nums[k];
                        if (!hs.ContainsKey(str)) {
                            hs[str] = new List<int>() {nums[i],nums[j], nums[k]};
                        }
                    }
                }
            }
        }

        return hs.Values.ToList();
    }
}