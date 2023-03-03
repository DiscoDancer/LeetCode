public class Solution {
    // grid MxN balls N
    // 1 right -1 left
    // ответ: столб где упадет, либо -1 если не упадет
    // меморизация выглядит ок

    // засунуть шарики в уровень -1
    // всегдп либо 1 либо 0 вариантов перемещения

    /*
        Roadmap: 
        + сделать без меморизации
    */

    private int[][] _grid;
    private int _X;
    private int _Y;

    private int F(int x, int y) {
        if (x == _X - 1) { // достигли последнюю строку
            return y;
        }

        // перемещаемся вправо по диагонали
        if (_grid[x+1][y] == 1 && y < _Y - 1 && _grid[x+1][y+1] == 1) {
            return F(x + 1, y+1);
        }
        // перемещаемся влево по диагонали
        if (_grid[x+1][y] == -1 && y > 0 && _grid[x+1][y-1] == -1) {
            return F(x + 1, y-1);
        }

        return -1;
    }

    // проходит без TL даже без меморизации
    public int[] FindBall(int[][] grid) {
        _grid = grid;
        _X = grid.Length;
        _Y = grid[0].Length;

        var result = new int[_Y];
        for (int i = 0; i < _Y; i++) {
            result[i] = F(-1, i);
        }

        return result;
    }
}