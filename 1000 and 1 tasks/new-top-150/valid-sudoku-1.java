class Solution {
    public boolean isValidSudoku(char[][] board) {

        var nrows = board.length;
        var ncols = board[0].length;

        var squareStates = new boolean[10][10];
        var rowStates = new boolean[10][10];
        var columnStates = new boolean[10][10];

        for (int i = 0; i < nrows; i++) {
            for (var j = 0; j < ncols; j++) {
                if (board[i][j] == '.') {
                    continue;
                }

                var line = i / 3;
                var col = j / 3;
                var squareIndex = line * 3 + col;

                var rowsState = rowStates[i];
                var colState = columnStates[j];
                var squareState = squareStates[squareIndex];

                var x = board[i][j] - '0';
                if (rowsState[x]) {
                    return false;
                }
                if (colState[x]) {
                    return false;
                }
                if (squareState[x]) {
                    return false;
                }

                squareState[x] = true;
                rowsState[x] = true;
                colState[x] = true;
            }
        }
        
        return true;
    }
}