public class Solution {
    public int[] NextGreaterElements(int[] nums) {
        var n = nums.Length;
        var res = new int[n];

        for (int i = 0; i < n; i++) {
            var j = (i + 1) % n;
            while (j != i && nums[j] <= nums[i]) {
                j++;
                j %= n;
            }
            if (j == i) {
                res[i] = -1;
            }
            else {
                res[i] = nums[j];
            }
        }

        return res;
    }
}