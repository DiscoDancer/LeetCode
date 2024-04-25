public class Solution {
    // https://leetcode.com/problems/jump-game-viii/solutions/2129666/c-solution-o-n-every-step-has-at-most-2-choices-first-larger-or-first-smaller/
    public long MinCost(int[] nums, int[] costs) {
        var minCosts = new long[nums.Length];
        Array.Fill(minCosts, long.MaxValue);
        minCosts[0] = 0;

        // видимо условия накладываются так, что нужно брать первого самого большого и первого самого малеького

        // в l копятся по уменьшению
        var l = new List<int>() {0};
        // в s копятся по увеличению, либо равно
        var s = new List<int>() {0};

        for (int i = 1; i < nums.Length; i++) {
            while (l.Any() && nums[l.Last()] <= nums[i]) {
                minCosts[i] = Math.Min(minCosts[i], minCosts[l.Last()] + costs[i]);
                l.RemoveAt(l.Count() - 1);
            }
            l.Add(i);

            while (s.Any() && nums[s.Last()] > nums[i]) {
                minCosts[i] = Math.Min(minCosts[i], minCosts[s.Last()] + costs[i]);
                s.RemoveAt(s.Count() - 1);
            }
            s.Add(i);
        }

        return minCosts.Last();
    }
}