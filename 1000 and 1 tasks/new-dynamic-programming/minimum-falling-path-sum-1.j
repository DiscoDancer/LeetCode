import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {
    public int minFallingPathSum(int[][] matrix) {
        var X = matrix.length;
        var Y = matrix[0].length;

        var prevLine = matrix[0];

        for (var lineI = 1; lineI < X; lineI++) {
            var curLine = new int[Y];
            for (var colI = 0; colI < Y; colI++) {
                var option1 = prevLine[colI];
                var option2 = colI > 0 ? prevLine[colI - 1] : Integer.MAX_VALUE;
                var option3 = colI < Y - 1 ? prevLine[colI + 1] : Integer.MAX_VALUE;

                curLine[colI] += Math.min(option1, Math.min(option2, option3)) + matrix[lineI][colI];
            }
            prevLine = curLine;
        }

        return Arrays.stream(prevLine).min().getAsInt();
    }
}
