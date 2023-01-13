public class Solution {
    public int MinPathSum(int[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;

        var prev = new int[n];
        prev[0] = grid[0][0];
        for (int i = 1; i < n; i++) {
            prev[i] = prev[i-1] + grid[0][i];
        }

        for (int i = 1; i < m; i++) {
            prev[0] += grid[i][0];
            for (int j = 1; j < n; j++) {
                prev[j] = grid[i][j] + Math.Min(prev[j-1], prev[j]);
            } 
        }

        return prev.Last();
    }
}