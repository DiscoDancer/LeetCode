public class Solution {
    public int SingleNumber(int[] nums) {
        var result = 0;

        foreach (var n in nums) {
            result ^= n;
        }

        return result;
    }
}