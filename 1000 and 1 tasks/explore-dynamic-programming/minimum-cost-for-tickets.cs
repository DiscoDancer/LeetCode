public class Solution {
    // 1 <= day <= 365
    // 1 day 7 day 30 day

    // проскакиевые дни
    // принимаем решение

    private int _min = int.MaxValue;
    private int[] _days;
    private int[] _costs;

    private void F(int dayIndex, int sum) {
        if (dayIndex == _days.Length) {
            _min = Math.Min(_min, sum);
            return;
        }

        // если мы здесь, значит у нас нет билета

        // покупаем 1 день
        F(dayIndex +1, sum + _costs[0]);

        // покупаем 7 дней
        var rangeEndInc = _days[dayIndex] + 6;

        var nextIndex = dayIndex + 1;
        while (nextIndex < _days.Length && _days[nextIndex] <= rangeEndInc) {
            nextIndex++;
        }

        F(nextIndex, _costs[1] + sum);

        // покупаем 30 дней
        rangeEndInc = _days[dayIndex] + 29;
        nextIndex = dayIndex + 1;
        while (nextIndex < _days.Length && _days[nextIndex] <= rangeEndInc) {
            nextIndex++;
        }
        F(nextIndex, _costs[2] + sum);
    }

    // TL
    public int MincostTickets(int[] days, int[] costs) {
        _days = days;
        _costs = costs;

        F(0,0);

        return _min;
    }
}