public class Solution {
    // https://leetcode.com/problems/smallest-range-ii/solutions/173389/simple-c-solution-with-explanation/
    public int SmallestRangeII(int[] nums, int k) {
        nums = nums.OrderBy(x => x).ToArray();
        // худший вариант, потому что между max и min самая большая разница
        var res = nums.Last() - nums.First();
        // едиственный вариант - к малеькому прибавлять k, а от большего отимать
        // только так можно получить минимальную ранзницу 
        var left = nums.First() + k;
        var right = nums.Last() - k;
        for (int i = 0; i < nums.Length - 1; i++) {
            // между соседями минимальная разница сама по себе
            // но мы пытается сделать ее еще лучше
            var maxi = Math.Max(nums[i] + k, right);
            var mini = Math.Min(left, nums[i + 1] - k);
            res = Math.Min(res, maxi - mini);
        }

        return res;
    }
}