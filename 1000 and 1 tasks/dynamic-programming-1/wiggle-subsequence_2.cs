public class Solution {
    // https://leetcode.com/problems/wiggle-subsequence/solutions/127714/wiggle-subsequence/?orderBy=most_votes
    public int WiggleMaxLength(int[] nums) {
        if (nums.Length == 1) {
            return nums.Length;
        }

        var positive = new int[nums.Length];
        var negative = new int[nums.Length];

        negative[0] = 1;
        positive[0] = 1;
        
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] > nums[i-1]) {
                negative[i] = negative[i-1];
                positive[i] = negative[i-1] + 1;
            }
            else if (nums[i] < nums[i - 1]) {
                negative[i] = positive[i-1] + 1;
                positive[i] = positive[i-1];
            }
            else {
                negative[i] = negative[i-1];
                positive[i] = positive[i-1];
            }
        }

        return Math.Max(positive.Last(), negative.Last());
    }
}