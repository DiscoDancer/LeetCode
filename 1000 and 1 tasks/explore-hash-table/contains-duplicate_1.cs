public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        if (nums.Length < 2) {
            return false;
        }

        Array.Sort(nums);

        var sortedNums = nums;
        var prev = sortedNums[0];
        for (int i = 1; i < sortedNums.Length; i++) {
            var cur = sortedNums[i];
            if (prev == cur) {
                return true;
            }
            prev = cur;
        }

        return false;
    }
}