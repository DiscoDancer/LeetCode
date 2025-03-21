import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {
    public int minPathSum(int[][] grid) {
        var X = grid.length;
        var Y = grid[0].length;

        var table = new int[X][Y];

        for (var lineIndex = 0; lineIndex < X; lineIndex++) {
            for (var colIndex = 0; colIndex < Y; colIndex++) {
                if (lineIndex == 0 && colIndex == 0) {
                    table[lineIndex][colIndex] = grid[lineIndex][colIndex];
                }
                else if (lineIndex == 0) {
                    table[lineIndex][colIndex] = table[lineIndex][colIndex - 1] + grid[lineIndex][colIndex];
                }
                else if (colIndex == 0) {
                    table[lineIndex][colIndex] = table[lineIndex - 1][colIndex] + grid[lineIndex][colIndex];
                }
                else {
                    table[lineIndex][colIndex] = Math.min(
                        table[lineIndex - 1][colIndex],
                        table[lineIndex][colIndex - 1]
                    ) + grid[lineIndex][colIndex];
                }
            }
        }

        return table[X - 1][Y - 1];
    }
}
