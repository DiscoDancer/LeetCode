public class Solution {
    public int Search(int[] nums, int target) {
        var a = 0;
        var b = nums.Length - 1;

        while (a <= b) {
            var m = a + (b-a)/2;
            if (nums[m] == target) {
                return m;
            }
            else if (nums[m] < target) {
                a = m + 1;
            }
            else {
                b = m - 1;
            }
        }

        return -1;
    }
}