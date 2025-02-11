class Solution {

    private int n;
    private int count;

    // map вообще не будет нужен
    private void F(int index, int insertedCount, boolean[] rows, boolean[] cols, boolean[] diag1, boolean[] diag2) {
        if (index == n*n) {
            if (insertedCount == n) {
                count++;
            }
            return;
        }

        var row = index / n;
        var col = index % n;

        // not put - always an option
        F(index + 1, insertedCount,rows, cols, diag1, diag2);

        // put - can we put?
        if (!rows[row] && !cols[col] && !diag1[row + col] && !diag2[row - col + n - 1]) {
            rows[row] = true;
            cols[col] = true;
            diag1[row + col] = true;
            diag2[row - col + n - 1] = true;
            F(index + 1, insertedCount + 1, rows, cols, diag1, diag2);
            rows[row] = false;
            cols[col] = false;
            diag1[row + col] = false;
            diag2[row - col + n - 1] = false;
        }
    }

    public int totalNQueens(int n) {
        this.n = n;

        F(0, 0, new boolean[n], new boolean[n], new boolean[1 + 2 *(n-1)], new boolean[1 + 2 *(n-1)]);

        return this.count;
    }
}