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

    private void F(int houseIndex, int prevColor, int currentScore, int currentSum) {
        // дошли до конца, выходим
        if (houseIndex == _m) {
            if (currentScore == _target) {
                _min = Math.Min(_min, currentSum);
            }
            return;
        }

        
        // могу покрасить, могу не покрасить
        // если крашу, то n цветов, какой выбрать?

        // если уже крашен, то идем дальше
        if (_houses[houseIndex] != 0) {
            var inc = _houses[houseIndex] == prevColor ? 0 : 1;
            F(houseIndex+1, _houses[houseIndex],  currentScore + inc, currentSum);
            return;
        }
        
        // крашу
        for (int color = 1; color <= _n; color++) {
            if (color == _houses[houseIndex]) {
                continue;
            }
            var inc = color == prevColor ? 0 : 1;
            F(houseIndex+1, color, currentScore + inc, currentSum + _cost[houseIndex][color-1]);
        }
    }


    // TL
    public int MinCost(int[] houses, int[][] cost, int m, int n, int target) {
        _houses = houses;
        _cost = cost;
        _m = m;
        _n = n;
        _target = target;

        F(0, -1, 0, 0);

        return _min == int.MaxValue ? -1 : _min;
    }
}