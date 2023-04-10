public class Solution {
    // n3
    // n2 (sums + ht)

    // TL
    public IList<IList<int>> ThreeSum(int[] nums) {
        var table = new Dictionary<int, List<int[]>>();

        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                var sum = nums[i] + nums[j];
                if (!table.ContainsKey(sum)) {
                    table[sum] = new ();
                }
                table[sum].Add(new int[] {i,j});
            }
        }

        var hs = new Dictionary<string, IList<int>>();

        for (int i = 0; i < nums.Length; i++) {
            var sum = nums[i];
            if (table.ContainsKey(-sum)) {
                foreach (var pair in table[-sum]) {
                    if (pair[0] != i && pair[1] != i) {
                        var arr = new int[] {nums[pair[0]],nums[pair[1]], nums[i]}.OrderBy(x => x).ToArray();
                        var a = arr[0];
                        var b = arr[1];
                        var c = arr[2];

                        var str = "" + a + b + c;
                        if (!hs.ContainsKey(str)) {
                            hs[str] = new List<int>() {a,b,c};
                        }
                    }
                }
            }
        }

        return hs.Values.ToList();
    }
}