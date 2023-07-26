public class Solution {
    private int[] _jobDifficulty;
    private int _d;

    private int F(int dayIndex, int jobIndex) {
        if (dayIndex == _d) {
            return 0;
        }

        var daysRemaining = _d - dayIndex;
        var jobsRemaining = _jobDifficulty.Length - jobIndex;
        var availableJobsForDay = jobsRemaining - daysRemaining + 1;

        if (dayIndex == _d -1) {
            var dayMax = 0;
            for (int i = 1; i <= availableJobsForDay; i++) {
                dayMax = Math.Max(dayMax, _jobDifficulty[jobIndex+i-1]);
            }
            return F(dayIndex+1, jobIndex + availableJobsForDay) + dayMax;
        }
        else {
            var dayMax = 0;
            var minResult = int.MaxValue;
            for (int i = 1; i <= availableJobsForDay; i++) {
                dayMax = Math.Max(dayMax, _jobDifficulty[jobIndex+i-1]);
                var result = F(dayIndex+1, jobIndex+i) + dayMax;
                minResult = Math.Min(minResult, result);
            }

            return minResult;
        }
    }

    public int MinDifficulty(int[] jobDifficulty, int d) {
        if (d > jobDifficulty.Length) {
            return -1;
        }

        _jobDifficulty = jobDifficulty;
        _d = d;

        return F(0, 0);
    }
}