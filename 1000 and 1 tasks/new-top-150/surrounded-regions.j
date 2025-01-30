import java.util.ArrayList;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Stack;

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 * int val;
 * TreeNode left;
 * TreeNode right;
 * TreeNode() {}
 * TreeNode(int val) { this.val = val; }
 * TreeNode(int val, TreeNode left, TreeNode right) {
 * this.val = val;
 * this.left = left;
 * this.right = right;
 * }
 * }
 */
class Solution {
    private record Point(int x, int y) {
    }

    public void solve(char[][] grid) {
        var X = grid.length;
        var Y = grid[0].length;

        var index = 0;
        var isSurrounded = new ArrayList<Boolean>();

        // sentinel
        isSurrounded.add(false);

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (grid[i][j] == 'O') {
                    Queue<Point> queue = new LinkedList<>();
                    queue.add(new Point(i, j));
                    index++;
                    var islandChar = (char)((int)'X' + index);
                    grid[i][j] = islandChar;

                    var isCurrentSurrounded = true;

                    while (!queue.isEmpty()) {
                        var point = queue.poll();
                        var x = point.x;
                        var y = point.y;

                        isCurrentSurrounded = isCurrentSurrounded && !(x == 0 || x == X - 1 || y == 0 || y == Y - 1);

                        if (x > 0 && grid[x - 1][y] == 'O') {
                            queue.add(new Point(x - 1, y));
                            grid[x - 1][y] = islandChar;
                        }
                        if (x < X - 1 && grid[x + 1][y] == 'O') {
                            queue.add(new Point(x + 1, y));
                            grid[x + 1][y] = islandChar;
                        }
                        if (y > 0 && grid[x][y - 1] == 'O') {
                            queue.add(new Point(x, y - 1));
                            grid[x][y - 1] = islandChar;
                        }
                        if (y < Y - 1 && grid[x][y + 1] == 'O') {
                            queue.add(new Point(x, y + 1));
                            grid[x][y + 1] = islandChar;
                        }
                    }

                    isSurrounded.add(isCurrentSurrounded);
                }
            }
        }

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (grid[i][j] != 'O' && grid[i][j] != 'X') {
                    var isSurroundedIsland = isSurrounded.get(grid[i][j] - 'X');
                    grid[i][j] = isSurroundedIsland ? 'X' : 'O';
                }
            }
        }
    }
}