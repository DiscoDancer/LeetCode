public class Solution {
    // editorial
    public IList<IList<int>> ThreeSum(int[] nums) {
        nums = nums.OrderBy(x => x).ToArray();

        var n = nums.Length;
        var result = new List<IList<int>>();
        var prev = int.MinValue;
        // nums[i] <= 0; -- If the current value is greater than zero, break from the loop. Remaining values cannot sum to zero.
        for (int i = 0; i < n && nums[i] <= 0; i++) {
            if (prev == nums[i]) continue;
            var target = nums[i] * (-1);
            var l = i + 1;
            var r = n - 1;
            while (l < r) {
                if (nums[l] + nums[r] == target) {
                    result.Add(new List<int>() {nums[i], nums[l], nums[r]});
                    l++;
                    r--;
                    // в этом вся суть, потому что оно позволяет гарантированно уезжать от дубликатов
                    while (l < r && nums[l-1] == nums[l]) l++;
                }
                else if (nums[l] + nums[r] < target) {
                    l++;
                }
                else {
                    r--;
                }
            }
            prev = nums[i];
        }

        return result;
    }
}