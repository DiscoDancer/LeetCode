public class Solution {
    public int SingleNumber(int[] nums) {
        var sorted = nums.OrderBy(x => x).ToArray();

        var prev = sorted[0];

        for (int i = 1; i < sorted.Length; i++) {
            if (sorted[i] != prev) {
                if (i == sorted.Length-1 || sorted[i] != sorted[i+1]) {
                    return sorted[i];
                }
            }
            prev = sorted[i];
        }

        return sorted[0];
    }
}