public class Solution {
    // TL
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff) {
        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                if (j - i <= indexDiff && Math.Abs(nums[i] - nums[j]) <= valueDiff) {
                    return true;
                }
            }
        }

        return false;
    }
}