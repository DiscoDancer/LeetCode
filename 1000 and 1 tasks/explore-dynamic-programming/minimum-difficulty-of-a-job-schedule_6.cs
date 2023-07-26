public class Solution {
    // editorial
    public int MinDifficulty(int[] jobDifficulty, int d) {
        int n = jobDifficulty.Length;

        // If we cannot schedule at least one job per day, 
        // it is impossible to create a schedule

        if (n < d) {
            return -1;
        }

        var dp = new int[n, d + 1];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < d + 1; j++) {
                dp[i,j] = int.MaxValue;
            }
        }

        // Set base cases
        dp[n - 1,d] = jobDifficulty[n - 1];
        // On the last day, we must schedule all remaining jobs, so dp[i][d]
        // is the maximum difficulty job remaining
        for (int i = n - 2; i >= 0; i--) {
            dp[i,d] = Math.Max(dp[i + 1,d], jobDifficulty[i]);
        }

        for (int day = d - 1; day > 0; day--) {
            for (int i = day - 1; i < n - (d - day); i++) {
                int hardest = 0;
                // Iterate through the options and choose the best
                for (int j = i; j < n - (d - day); j++) {
                    hardest = Math.Max(hardest, jobDifficulty[j]);
                    // Recurrence relation
                    dp[i,day] = Math.Min(dp[i,day], hardest + dp[j + 1,day + 1]);
                }
            }
        }
        
        return dp[0,1];
    }
}