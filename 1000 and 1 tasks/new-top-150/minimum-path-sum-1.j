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

        return F(0, 0);

        // return min;
    }
}
