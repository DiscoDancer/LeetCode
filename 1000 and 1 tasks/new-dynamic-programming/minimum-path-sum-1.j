import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Arrays;

class Solution {
    public int minPathSum(int[][] grid) {
        var X = grid.length;
        var Y = grid[0].length;

        for (var lineIndex = 0; lineIndex < X; lineIndex++) {
            for (var colIndex = 0; colIndex < Y; colIndex++) {
                if (lineIndex == 0 && colIndex == 0) {
                    grid[lineIndex][colIndex] = -grid[lineIndex][colIndex];
                }
                else if (lineIndex == 0) {
                    grid[lineIndex][colIndex] = -(-grid[lineIndex][colIndex - 1] + grid[lineIndex][colIndex]);
                }
                else if (colIndex == 0) {
                    grid[lineIndex][colIndex] = -(-grid[lineIndex - 1][colIndex] + grid[lineIndex][colIndex]);
                }
                else {
                    grid[lineIndex][colIndex] = -Math.min(
                            -grid[lineIndex - 1][colIndex],
                            -grid[lineIndex][colIndex - 1]
                    ) + -grid[lineIndex][colIndex];
                }
            }
        }

        return -grid[X - 1][Y - 1];
    }
}
