public class Solution {

    public bool IsCharValid(char x) {
        return x >= '1' && x <= '9' || x == '.';
    }

    public bool IsValidSudoku(char[][] board) {
        var columns = new bool[9][];
        var grids = new bool[9][];

        for (int i = 0; i < 9; i++) {
            columns[i] = new bool[10];
            grids[i] = new bool[10];
        }

        for (int i = 0; i < 9; i++) {
            var line = new bool[10];
            for (int j = 0; j < 9; j++) {
                var chr = board[i][j];
                if (!IsCharValid(chr)) {
                    return false;
                }
                if (char.IsDigit(chr)) {
                    if (line[chr - '0']) {
                        return false;
                    }
                    line[chr - '0'] = true;
                    if (columns[j][chr-'0']) {
                        return false;
                    }
                    if (grids[i / 3 * 3 + j / 3][chr-'0']) {
                        return false;
                    }
                    grids[i / 3 * 3 + j / 3][chr-'0'] = true;
                    columns[j][chr-'0'] = true;
                }
            }

        }

        return true;
    }
}