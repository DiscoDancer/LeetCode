public class Solution {
    public int MissingElement(int[] nums, int k) {
        var prev = nums[0];

        for (int i = 1; i < nums.Length; i++) {
            var cur = nums[i];

            var missingCount = cur - prev - 1;
            if (k <= missingCount) {
                return prev + k;
            }
            else {
                k -= missingCount;
            }

            prev = cur;
        }

        return nums.Last()+k;
    }
}