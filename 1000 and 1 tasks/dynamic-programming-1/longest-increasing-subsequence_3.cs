public class Solution {
    // https://leetcode.com/problems/longest-increasing-subsequence/submissions/
    public int LengthOfLIS(int[] nums) {
        var sub = new List<int>() {nums[0]};

        for (var i = 1; i < nums.Length; i++) {
            var num = nums[i];
            if (num > sub.Last()) {
                sub.Add(num);
            }
            else {
                // Find the first element in sub that is greater than or equal to num
                var j = 0;
                while (num > sub.ElementAt(j)) {
                    j += 1;
                }
                sub[j] = num;
            }
        }

        return sub.Count();
    }
}
