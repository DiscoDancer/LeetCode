public class Solution {
    private int[] _jobDifficulty;
    private int[] _fastMax;
    private int _d;
    private int?[,] _mem;

    private int F(int dayIndex, int jobIndex) {
        if (dayIndex == _d) {
            return 0;
        }
        if (_mem[dayIndex, jobIndex] != null) {
            return _mem[dayIndex, jobIndex].Value;
        }

        var daysRemaining = _d - dayIndex;
        var jobsRemaining = _jobDifficulty.Length - jobIndex;
        var availableJobsForDay = jobsRemaining - daysRemaining + 1;

        if (dayIndex == _d -1) {
            var dayMax = _fastMax[jobIndex];
            _mem[dayIndex, jobIndex] = F(dayIndex+1, jobIndex + availableJobsForDay) + dayMax;
            return  _mem[dayIndex, jobIndex].Value;
        }
        else {
            var dayMax = 0;
            var minResult = int.MaxValue;
            for (int i = 1; i <= availableJobsForDay; i++) {
                dayMax = Math.Max(dayMax, _jobDifficulty[jobIndex+i-1]);
                var result = F(dayIndex+1, jobIndex+i) + dayMax;
                minResult = Math.Min(minResult, result);
            }

            _mem[dayIndex, jobIndex] = minResult;

            return minResult;
        }
    }

    // passes, previously mem didn't work
    public int MinDifficulty(int[] jobDifficulty, int d) {
        if (d > jobDifficulty.Length) {
            return -1;
        }

        _fastMax = new int[jobDifficulty.Length];
        _fastMax[jobDifficulty.Length-1] = jobDifficulty[jobDifficulty.Length-1];
        for (int i = jobDifficulty.Length - 2; i >= 0; i--) {
            _fastMax[i] = Math.Max(_fastMax[i+1], jobDifficulty[i]);
        }

        _mem = new int?[d, jobDifficulty.Length];

        _jobDifficulty = jobDifficulty;
        _d = d;

        return F(0, 0);
    }
}