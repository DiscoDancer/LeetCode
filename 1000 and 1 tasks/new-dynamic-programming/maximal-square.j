import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;


// editorial но я вспомнил сам
// еще можно через 4 квадрата и range queries

class Solution {
    public int maximalSquare(char[][] matrix) {

        var X = matrix.length;
        var Y = matrix[0].length;

        var table = new int[X][Y];

        var max = 0;

        for (var lineI = 0; lineI < X; ++lineI) {
            for (var columnI = 0; columnI < Y; ++columnI) {
                var pointA = lineI > 0 && columnI > 0 ? table[lineI - 1][columnI - 1] : 0;
                var pointB = lineI > 0 ? table[lineI - 1][columnI] : 0;
                var pointC = columnI > 0 ? table[lineI][columnI - 1] : 0;

                if (matrix[lineI][columnI] == '1') {
                    table[lineI][columnI] = Math.min(pointA, Math.min(pointB, pointC)) + 1;
                    max = Math.max(max, table[lineI][columnI]);
                }
            }
        }

        return max*max;
    }
}
