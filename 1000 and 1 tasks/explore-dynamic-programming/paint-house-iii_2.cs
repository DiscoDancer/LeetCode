public class Solution {
    // m домов (0 based)
    // n цветов (1 based)
    // cost - сколько покрасить дом в цвет

    // 3 переменных в стейте

    private int[] _houses;
    private int[][] _cost;
    private int _m;
    private int _n;
    private int _target;

    private int _min = int.MaxValue;

    // пусть score тоже считается заново

    // попробовать меморизацию от 3х
    // мб current score можно посчитать? или вернуть tuple

    private Dictionary<(int,int,int), int> _mem = new ();

    private int F(int houseIndex, int prevColor, int currentScore) {
        // дошли до конца, выходим
        if (houseIndex == _m) {
            if (currentScore == _target) {
                return 0;
            }
            return int.MaxValue;
        }
        if (currentScore > _target) {
            return int.MaxValue;
        }

        if (_mem.ContainsKey((houseIndex, prevColor, currentScore))) {
            return _mem[(houseIndex, prevColor, currentScore)];
        }
        
        // могу покрасить, могу не покрасить
        // если крашу, то n цветов, какой выбрать?

        // если уже крашен, то идем дальше
        if (_houses[houseIndex] != 0) {
            var inc = _houses[houseIndex] == prevColor ? 0 : 1;
            return F(houseIndex+1, _houses[houseIndex],  currentScore + inc);
        }

        var min = int.MaxValue;
        // крашу
        for (int color = 1; color <= _n; color++) {
            var inc = color == prevColor ? 0 : 1;
            var sub = F(houseIndex+1, color, currentScore + inc);
            if (sub < int.MaxValue) {
                min = Math.Min (sub + _cost[houseIndex][color-1], min);
            }
        }

        _mem[(houseIndex, prevColor, currentScore)] = min;

        return min;
    }


    // accepted
    public int MinCost(int[] houses, int[][] cost, int m, int n, int target) {
        _houses = houses;
        _cost = cost;
        _m = m;
        _n = n;
        _target = target;

        var _min = F(0, -1, 0);

        return _min == int.MaxValue ? -1 : _min;
    }
}