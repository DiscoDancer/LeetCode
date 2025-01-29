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
    public int numIslands(char[][] grid) {
        var X = grid.length;
        var Y = grid[0].length;

        var result = 0;

        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                if (grid[i][j] == '1') {
                    Queue<Point> queue = new LinkedList<>();
                    queue.add(new Point(i, j));
                    result++;

                    while (!queue.isEmpty()) {
                        var point = queue.poll();
                        var x = point.x;
                        var y = point.y;

                        if (x > 0 && grid[x - 1][y] == '1') {
                            queue.add(new Point(x - 1, y));
                            grid[x - 1][y] = '0';
                        }
                        if (x < X - 1 && grid[x + 1][y] == '1') {
                            queue.add(new Point(x + 1, y));
                            grid[x + 1][y] = '0';
                        }
                        if (y > 0 && grid[x][y - 1] == '1') {
                            queue.add(new Point(x, y - 1));
                            grid[x][y - 1] = '0';
                        }
                        if (y < Y - 1 && grid[x][y + 1] == '1') {
                            queue.add(new Point(x, y + 1));
                            grid[x][y + 1] = '0';
                        }
                    }
                }
            }
        }

        return result;
    }
}