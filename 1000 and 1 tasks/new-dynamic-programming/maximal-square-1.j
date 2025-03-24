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

        var prevLine = new int[Y];
        var max = 0;

        for (var lineI = 0; lineI < X; ++lineI) {
            var curLine = new int[Y];
            for (var columnI = 0; columnI < Y; ++columnI) {
                var pointA = lineI > 0 && columnI > 0 ? prevLine[columnI - 1] : 0;
                var pointB = lineI > 0 ? prevLine[columnI] : 0;
                var pointC = columnI > 0 ? curLine[columnI - 1] : 0;

                if (matrix[lineI][columnI] == '1') {
                    curLine[columnI] = Math.min(pointA, Math.min(pointB, pointC)) + 1;
                    max = Math.max(max, curLine[columnI]);
                }
            }
            prevLine = curLine;
        }

        return max*max;
    }
}
