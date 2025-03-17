import java.util.ArrayDeque;
import java.util.List;

class Solution {

    // public int min = Integer.MAX_VALUE;
    public int[][] grid;

    public int F(int x, int y) {

        var X = grid.length;
        var Y = grid[0].length;

        if (x == X - 1 && y == Y - 1) {
            return grid[x][y];
        }

        int goRight = y < Y - 1 ? F(x, y + 1) : Integer.MAX_VALUE;
        int goDown = x < X - 1 ? F(x + 1, y) : Integer.MAX_VALUE;

        var min = Math.min(goRight, goDown);
        return min + grid[x][y];
    }

    public int minPathSum(int[][] grid) {
        this.grid = grid;

        var X = grid.length;
        var Y = grid[0].length;

        var table = new int[X][Y];

        for (var x = X-1; x >=0; x--) {
            for (var y = Y-1; y >=0; y--) {
                if (x == X - 1 && y == Y - 1) {
                    table[x][y] = grid[x][y];
                } else {
                    int goRight = y < Y - 1 ? table[x][y + 1] : Integer.MAX_VALUE;
                    int goDown = x < X - 1 ? table[x + 1][y] : Integer.MAX_VALUE;
                    table[x][y] = Math.min(goRight, goDown) + grid[x][y];
                }
            }
        }

        return  table[0][0];
    }
}
