class Solution {

    private int[][] grid;
    private int[][] sums;

    private int CalcAbove(int x0, int y0, int size) {
        if (x0 == 0) {
            return 0;
        }
        return sums[x0 - 1][y0 + size - 1];
    }

    private int CalcLeft(int x0, int y0, int size) {
        if (y0 == 0) {
            return 0;
        }
        return sums[x0 + size - 1][y0 - 1];
    }

    private int CalcIntersection(int x0, int y0) {
        if (x0 == 0 || y0 == 0) {
            return 0;
        }
        return sums[x0 - 1][y0 - 1];
    }

    private Node F(int x0, int y0, int size) {
        if (size < 1) {
            return null;
        }
        if (size == 1) {
            return new Node(grid[x0][y0] == 1, true);
        }

        var above = CalcAbove(x0, y0, size);
        var left = CalcLeft(x0, y0, size);
        var full_xn_yn = sums[x0 + size - 1][y0 + size - 1];
        var intersection = CalcIntersection(x0, y0);
        var sum = full_xn_yn - above - left + intersection;

        var isStop = sum == size * size || sum == 0;

        if (isStop) {
            return new Node(sum == size * size, true);
        }

        var topLeft = F(x0, y0, size / 2);
        var topRight = F(x0, y0 + size / 2, size / 2);
        var bottomLeft = F(x0 + size / 2, y0, size / 2);
        var bottomRight = F(x0 + size / 2, y0 + size / 2, size / 2);

        return new Node(false, false, topLeft, topRight, bottomLeft, bottomRight);
    }

    public Node construct(int[][] grid) {
        this.grid = grid;
        var n = grid.length;
        this.sums = new int[n][n];

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (j > 0) {
                    sums[i][j] += sums[i][j - 1];
                }
                sums[i][j] += grid[i][j];
            }
        }

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (i > 0) {
                    sums[i][j] += sums[i - 1][j];
                }
            }
        }

        return F(0, 0, n);
    }
}