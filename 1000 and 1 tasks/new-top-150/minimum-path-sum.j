import java.util.ArrayDeque;
import java.util.List;

class Solution {

    public record Point(int x, int y, int sum) {}

    public int minPathSum(int[][] grid) {

        var X = grid.length;
        var Y = grid[0].length;

        var distances = new int[X][Y];

        for (int i = 0; i < X; i++)
            for (int j = 0; j < Y; j++)
                distances[i][j] = Integer.MAX_VALUE;

        distances[X-1][Y-1] = grid[X-1][Y-1];

        var queue = new ArrayDeque<Point>();
        queue.add(new Point(X-1, Y-1, grid[X-1][Y-1]));

        while (!queue.isEmpty()) {
            var curr = queue.poll();

            // left
            if (curr.y > 0 && distances[curr.x][curr.y-1] > curr.sum + grid[curr.x][curr.y-1]) {
                distances[curr.x][curr.y-1] = curr.sum + grid[curr.x][curr.y-1];
                queue.add(new Point(curr.x, curr.y-1, curr.sum + grid[curr.x][curr.y-1]));
            }
//            // right
//            if (curr.y < Y-1 && distances[curr.x][curr.y+1] > curr.sum + grid[curr.x][curr.y+1]) {
//                distances[curr.x][curr.y+1] = curr.sum + grid[curr.x][curr.y+1];
//                queue.add(new Point(curr.x, curr.y+1, curr.sum + grid[curr.x][curr.y+1]));
//            }
            // top
            if (curr.x > 0 && distances[curr.x-1][curr.y] > curr.sum + grid[curr.x-1][curr.y]) {
                distances[curr.x-1][curr.y] = curr.sum + grid[curr.x-1][curr.y];
                queue.add(new Point(curr.x-1, curr.y, curr.sum + grid[curr.x-1][curr.y]));
            }
//            // bottom
//            if (curr.x < X-1 && distances[curr.x+1][curr.y] > curr.sum + grid[curr.x+1][curr.y]) {
//                distances[curr.x+1][curr.y] = curr.sum + grid[curr.x+1][curr.y];
//                queue.add(new Point(curr.x+1, curr.y, curr.sum + grid[curr.x+1][curr.y]));
//            }
        }


        return distances[0][0];
    }
}
