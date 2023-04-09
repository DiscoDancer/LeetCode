public class Solution {
    // https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/editorial/
    public IList<int> FindDisappearedNumbers(int[] nums) {
        for (int i = 0; i < nums.Length; i++) {
            var newIndex = Math.Abs(nums[i]) - 1;
            if (nums[newIndex] > 0) {
                nums[newIndex] *= -1;
            }
        }

        var result = new List<int>();
        for (int i = 1; i <= nums.Length; i++) {
            
            if (nums[i - 1] > 0) {
                result.Add(i);
            }
        }

        return result;
    }
}