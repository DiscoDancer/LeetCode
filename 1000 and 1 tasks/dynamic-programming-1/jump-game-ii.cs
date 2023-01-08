public class Solution {
    public int Jump(int[] nums) {
        var res = new int?[nums.Length];
        res[0] = 0;

        for (int i = 0; i < nums.Length; i++) {
            for (int j = 0; j < nums[i]; j++) {
                var far = i + j + 1;
                if (far < nums.Length) {
                    if (res[far] == null) {
                        res[far] =  res[i].Value + 1;
                    }
                    else {
                        res[far] = Math.Min(res[far].Value, res[i].Value + 1);
                    }
                }
            }
        }

        return res.Last().Value;
    }
}