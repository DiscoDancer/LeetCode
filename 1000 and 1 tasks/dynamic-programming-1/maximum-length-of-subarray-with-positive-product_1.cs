public class Solution {
    // https://leetcode.com/problems/maximum-length-of-subarray-with-positive-product/solutions/820072/easy-soultion-with-dry-run-java/
    public int GetMaxLen(int[] nums) {
        var max = 0;
        var scorePositive = 0;
        var scoreNegative = 0;
        var prevSign = true;

        foreach (var n in nums) {
            if (n == 0) {
                scorePositive = 0;
                scoreNegative = 0;
                continue;
            }
            else if (n > 0) {
                scorePositive++;
                if (scoreNegative > 0) {
                    scoreNegative++;
                }
            }
            else {
                var tmp = scorePositive;
                scorePositive = scoreNegative > 0 ? scoreNegative + 1 : 0;
                scoreNegative = tmp + 1;
            }
            max = Math.Max(max, scorePositive);
        }

        return max;
    }
}