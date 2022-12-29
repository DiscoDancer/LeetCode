public class Solution {
    public bool ContainsDuplicate(int[] nums) {
        var sorted = nums.OrderBy(x => x).ToArray();
        var prev = sorted[0];

        for (int i = 1; i < sorted.Length; i++) {
            if (sorted[i] == prev) {
                return true;
            }
            prev = sorted[i];
        }

        return false;
    }
}