// editorial
public class Solution {
    public int MaxResult(int[] nums, int k) {
        int n = nums.Length;
        int[] score = new int[n];
        score[0] = nums[0];
        // we store indexes
        var dq = new List<int>() {0};

        for (int i = 1; i < n; i++) {
            // pop the old index
            while (dq.Any() && dq.First() < i - k) {
                dq.RemoveAt(0);
            }
            score[i] = score[dq.First()] + nums[i];

            // pop the smaller value
            while (dq.Any() && score[i] >= score[dq.Last()]) {
                dq.RemoveAt(dq.Count()-1);
            }
            dq.Add(i);
        }

        return score[n - 1];
    }
}