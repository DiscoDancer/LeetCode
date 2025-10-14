import java.util.*;


class Solution {
    public record Pair(int x, int y) {}

    public int maxAreaOfIsland(int[][] grid) {
        var map = new int[grid.length][grid[0].length];
        var nextIslandNumber = 1;

        var ht = new Hashtable<Integer, Integer>();

        var X = grid.length;
        var Y = grid[0].length;

        for (int i = 0; i < grid.length; i++) {
            for (int j = 0; j < grid[0].length; j++) {
                if (grid[i][j] == 1 && map[i][j] == 0) {
                    var islandNumber = nextIslandNumber++;
                    ht.put(islandNumber, 0);

                    var queue = new ArrayDeque<Pair>();
                    queue.add(new Pair(i, j));
                    while (!queue.isEmpty()) {
                        var pair = queue.poll();
                        var x = pair.x;
                        var y = pair.y;

                        map[x][y] = islandNumber;
                        ht.put(islandNumber, ht.getOrDefault(islandNumber, 0) + 1);

                        if (x < X - 1 && map[x+1][y] == 0 && grid[x+1][y] == 1) {
                            map[x+1][y] = islandNumber;
                            queue.add(new Pair(x+1, y));
                        }
                        if (x > 0 && map[x-1][y] == 0  && grid[x-1][y] == 1) {
                            map[x-1][y] = islandNumber;
                            queue.add(new Pair(x-1, y));
                        }
                        if (y < Y - 1 && map[x][y+1] == 0  && grid[x][y+1] == 1) {
                            map[x][y + 1] = islandNumber;
                            queue.add(new Pair(x, y+1));
                        }
                        if (y > 0 && map[x][y-1] == 0   && grid[x][y-1] == 1) {
                            map[x][y - 1] = islandNumber;
                            queue.add(new Pair(x, y-1));
                        }
                    }
                }
            }
        }

        var max = 0;
        for(var x: ht.values()) {
            max = Math.max(max, x);
        }

        return max;
    }
}