import java.math.BigInteger;
import java.util.*;

class Solution {

    public int minimumEffortPath(int[][] heights) {

        int X = heights.length;
        int Y = heights[0].length;

        var dist = new int[X][Y];

        for (int i = 0; i < X; i++) {
            Arrays.fill(dist[i], Integer.MAX_VALUE);
        }

        dist[0][0] = 0;

        Queue<int[]> queue = new LinkedList<>();
        queue.offer(new int[]{0, 0});

        while (!queue.isEmpty()) {
            var current = queue.poll();
            var x = current[0];
            var y = current[1];
            
            // Math.abs(heights[x][y] - heights[x - 1][y]) - по условию, ничего интересного
            // Math.max(dist[x][y], Math.abs(heights[x][y] - heights[x - 1][y]) - значит, что даже если разниа меньше, мы не может уменьшить значение

            if (x > 0 && dist[x - 1][y] > Math.max(dist[x][y], Math.abs(heights[x][y] - heights[x - 1][y])) ) {
                dist[x - 1][y] =  Math.max(dist[x][y], Math.abs(heights[x][y] - heights[x - 1][y]));
                queue.offer(new int[]{x - 1, y});
            }
            if (x < X - 1 && dist[x + 1][y] > Math.max(dist[x][y], Math.abs(heights[x][y] - heights[x + 1][y]))) {
                dist[x + 1][y] =Math.max(dist[x][y],  Math.abs(heights[x][y] - heights[x + 1][y]));
                queue.offer(new int[]{x + 1, y});
            }

            if (y > 0 && dist[x][y - 1] > Math.max(dist[x][y], Math.abs(heights[x][y] - heights[x][y - 1]))) {
                dist[x][y - 1] = Math.max(dist[x][y], Math.abs(heights[x][y] - heights[x][y - 1]));
                queue.offer(new int[]{x, y - 1});
            }
            if (y < Y - 1 && dist[x][y + 1] > Math.max(dist[x][y], Math.abs(heights[x][y] - heights[x][y + 1]))) {
                dist[x][y + 1] = Math.max(dist[x][y], Math.abs(heights[x][y] - heights[x][y + 1]));
                queue.offer(new int[]{x, y + 1});
            }
        }

        return dist[X - 1][Y - 1];
    }
}