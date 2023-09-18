public class Solution {
    public int SmallestDistancePair(int[] nums, int k) {
        var table = new int[1_000_001];

        for (int i = 0; i < nums.Length; i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                table[Math.Abs(nums[i] - nums[j])]++;
            }
        }

        var count = 0;

        for (int i = 0; i < 1_000_001; i++ ) {
            if (table[i] > 0) {
                count += table[i];
                if (count >= k) {
                    return i;
                }
            }
        }

        return -1;
    }
}