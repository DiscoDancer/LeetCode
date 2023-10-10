public class Solution {
    // сортировка
    public int MaxOperations(int[] nums, int k) {
        Array.Sort(nums);

        var l = 0;
        var r = nums.Length - 1;

        var result = 0;

        while (l < r) {
            if (nums[l] + nums[r] < k) {
                l++;
            }
            else if (nums[l] + nums[r] > k) {
                r--;
            }
            else {
                l++;
                r--;
                result++;
            }
        }

        return result;
    }
}