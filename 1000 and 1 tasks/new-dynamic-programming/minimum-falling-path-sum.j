import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {
    public int minFallingPathSum(int[][] matrix) {
        var X = matrix.length;
        var Y = matrix[0].length;

        for (var lineI = 1; lineI < X; lineI++) {
            for (var colI = 0; colI < Y; colI++) {
                var option1 = matrix[lineI - 1][colI];
                var option2 = colI > 0 ? matrix[lineI - 1][colI - 1] : Integer.MAX_VALUE;
                var option3 = colI < Y - 1 ? matrix[lineI - 1][colI + 1] : Integer.MAX_VALUE;

                matrix[lineI][colI] += Math.min(option1, Math.min(option2, option3));
            }
        }

        return Arrays.stream(matrix[X-1]).min().getAsInt();
    }
}
