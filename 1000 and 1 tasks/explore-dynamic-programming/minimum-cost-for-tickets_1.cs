public class Solution {
    private int[] _days;
    private int[] _costs;

    private int F(int dayIndex) {
        if (dayIndex == _days.Length) {
            return 0;
        }

        var d1 = 0;
        var d7 = 0;
        var d30 = 0;

        // покупаем 1 день
        d1 = F(dayIndex +1) + _costs[0];

        // покупаем 7 дней
        var rangeEndInc = _days[dayIndex] + 6;

        var nextIndex = dayIndex + 1;
        while (nextIndex < _days.Length && _days[nextIndex] <= rangeEndInc) {
            nextIndex++;
        }

        d7 = F(nextIndex) + _costs[1];

        // покупаем 30 дней
        rangeEndInc = _days[dayIndex] + 29;
        nextIndex = dayIndex + 1;
        while (nextIndex < _days.Length && _days[nextIndex] <= rangeEndInc) {
            nextIndex++;
        }
        d30 = F(nextIndex) + _costs[2];

        return Math.Min(d1,Math.Min(d7,d30));
    }

    // TL
    public int MincostTickets(int[] days, int[] costs) {
        _days = days;
        _costs = costs;

        return F(0);
    }
}