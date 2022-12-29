public class Solution {
    public int SearchInsert(int[] nums, int target) {
        var a = 0;
        var b = nums.Length - 1;

        while (a <= b) {
            var m = a + (b-a)/2;
            if (nums[m] == target) {
                return m;
            }
            else if (nums[m] > target) {
                b = m - 1;
            }
            else {
                a = m + 1;
            }
        }

        return b + 1;
    }
}