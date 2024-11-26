class Solution {
    public boolean isValidSudoku(char[][] board) {

        var nrows = board.length;
        var ncols = board[0].length;

        for (int i = 0; i < nrows; i++) {
            var rowsState = new boolean[10];
            for (var j = 0; j < ncols; j++) {
                if (board[i][j] == '.') {
                    continue;
                }

                var x = board[i][j] - '0';
                if (rowsState[x]) {
                    return false;
                }
                rowsState[x] = true;
            }
        }

        for (int j = 0; j < ncols; j++) {
            var colState = new boolean[10];
            for (var i = 0; i < nrows; i++) {
                if (board[i][j] == '.') {
                    continue;
                }

                var x = board[i][j] - '0';
                if (colState[x]) {
                    return false;
                }
                colState[x] = true;
            }
        }

        var squareStates = new boolean[10][10];

        for (int i = 0; i < nrows; i++) {
            for (var j = 0; j < ncols; j++) {
                if (board[i][j] == '.') {
                    continue;
                }
                // line *3 + col
                var line = i / 3;
                var col = j / 3;
                var squareIndex = line * 3 + col;

                var x = board[i][j] - '0';
                if (squareStates[squareIndex][x]) {
                    return false;
                }
                squareStates[squareIndex][x] = true;
            }
        }

        // todo check squares

        return true;
    }
}