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
        var prev = -1; // init value not important it is being overwritten

        for (var lineI = 0; lineI < X; ++lineI) {
            for (var columnI = 0; columnI < Y; ++columnI) {
                var old = prevLine[columnI];
                var pointA = lineI > 0 && columnI > 0 ? prevLine[columnI - 1] : 0;
                var pointB = lineI > 0 ? prevLine[columnI] : 0;
                var pointC = columnI > 0 ? prev : 0;

                if (matrix[lineI][columnI] == '1') {
                    prevLine[columnI] = Math.min(pointA, Math.min(pointB, pointC)) + 1;
                    max = Math.max(max, prevLine[columnI]);
                }
                else {
                    prevLine[columnI] = 0;
                }
                prev = old;
            }
        }

        return max*max;
    }
}
