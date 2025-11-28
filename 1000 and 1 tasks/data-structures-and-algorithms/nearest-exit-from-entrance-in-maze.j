import java.util.*;


class Solution {

    public record Cell(int x, int y) {}

    public int nearestExit(char[][] maze, int[] entrance) {
        var X = maze.length;
        var Y = maze[0].length;
        boolean[][] visited = new boolean[maze.length][maze[0].length];
        visited[entrance[0]][entrance[1]] = true;

        var queue = new ArrayDeque<Cell>();
        queue.offer(new Cell(entrance[0], entrance[1]));

        var stepsCounter = 0;
        while (!queue.isEmpty()) {
            var size = queue.size();
            for (int i = 0; i < size; i++) {
                var cell = queue.poll();
                var x = cell.x;
                var y = cell.y;

                if (!(x == entrance[0] && y == entrance[1])) {
                    if (x == 0 || x == X - 1 || y == 0 || y == Y - 1) {
                        return stepsCounter;
                    }
                }

                if (x < X - 1 && !visited[x + 1][y] && maze[x + 1][y] == '.') {
                    visited[x + 1][y] = true;
                    queue.offer(new Cell(x + 1, y));
                }
                if (x > 0 && !visited[x - 1][y] && maze[x - 1][y] == '.') {
                    visited[x - 1][y] = true;
                    queue.offer(new Cell(x - 1, y));
                }

                if (y < Y - 1 && !visited[x][y + 1] && maze[x][y+1] == '.') {
                    visited[x][y + 1] = true;
                    queue.offer(new Cell(x, y + 1));
                }
                if (y > 0 && !visited[x][y - 1] && maze[x][y-1] == '.') {
                    visited[x][y - 1] = true;
                    queue.offer(new Cell(x, y - 1));
                }

            }
            stepsCounter++;
        }

        return -1;
    }
}