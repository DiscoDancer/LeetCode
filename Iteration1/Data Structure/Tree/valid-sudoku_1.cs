public class Solution {
    public bool IsValidSudoku(char[][] board) {
        var rows = new int[9];
        var cols = new int[9];
        var squares = new int[9];

        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                if (board[i][j] == '.') {
                    continue;
                }
                
                var digit = board[i][j] - '0';
                var shift = 1 << (digit - 1);
                if ( (rows[i] & shift) > 0) {
                    return false;
                }
                rows[i] |= shift;

                if ( (cols[j] & shift ) > 0) {
                    return false;
                }
                cols[j] |= shift;

                var sqIndex = (i / 3) * 3 + j / 3;
                if ( (squares[sqIndex] & shift) > 0) {
                    return false;
                }
                squares[sqIndex] |= shift;
            }
        }

        return true;
    }
}