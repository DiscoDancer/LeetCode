public class Solution {
    public int Search(int[] nums, int target) {
        var n = nums.Length;
        var a = 0;
        var b = n - 1;

        while (a <= b) {
            var m = a + (b-a)/2;
            if (nums[m] == target) {
                return m;
            }
            else if (nums[m] < target) {
                a = m+1;
            }
            else if (nums[m] > target) {
                b = m -1;
            }
        }

        return -1;
    }
}