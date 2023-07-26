public class Solution {
    private int[] _jobDifficulty;
    private int _d;
    private int _min = int.MaxValue;


    private void F(int dayIndex, int jobIndex, int sum) {
        if (dayIndex == _d) {
            _min = Math.Min(_min, sum);
            return;
        }

        var daysRemaining = _d - dayIndex;
        var jobsRemaining = _jobDifficulty.Length - jobIndex;
        var availableJobsForDay = jobsRemaining - daysRemaining + 1;

        if (dayIndex == _d -1) {
            var dayMax = 0;
            for (int i = 1; i <= availableJobsForDay; i++) {
                dayMax = Math.Max(dayMax, _jobDifficulty[jobIndex+i-1]);
            }
            F(dayIndex+1, jobIndex + availableJobsForDay, sum + dayMax);
        }
        else {
            var dayMax = 0;
            for (int i = 1; i <= availableJobsForDay; i++) {
                dayMax = Math.Max(dayMax, _jobDifficulty[jobIndex+i-1]);
                F(dayIndex+1, jobIndex+i, sum + dayMax);
            }
        }
    }

    // TL
    public int MinDifficulty(int[] jobDifficulty, int d) {
        if (d > jobDifficulty.Length) {
            return -1;
        }

        _jobDifficulty = jobDifficulty;
        _d = d;

        F(0, 0, 0);

        return _min;
    }
}