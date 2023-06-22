public class Solution {
    public bool IsValidSudoku(char[][] board) {
        var rows = new bool[9][];
        var cols = new bool[9][];
        var grids = new bool[9][];

        for (var i = 0; i < 9; i++)
        {
            rows[i] = new bool[9];
            cols[i] = new bool[9];
            grids[i] = new bool[9];
        }

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] == '.')
                {
                    continue;
                }

                var digit = board[i][j] - '0';
                var digitAsIndex = digit - 1;

                // check rows and cols
                var gridIndex = (i / 3) * 3 + j / 3;
                if (rows[i][digitAsIndex] || cols[j][digitAsIndex] || grids[gridIndex][digitAsIndex])
                {
                    return false;
                }
                rows[i][digitAsIndex] = true;
                cols[j][digitAsIndex] = true;
                grids[gridIndex][digitAsIndex] = true;
            }
        }

        return true;
    }
}