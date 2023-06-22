public class Solution
{

    public bool IsCharValid(char x)
    {
        return x >= '1' && x <= '9' || x == '.';
    }

    public bool IsValidSudoku(char[][] board)
    {
        var columns = new int[9];
        var grids = new int[9];

        for (var i = 0; i < 9; i++)
        {
            var line = 0;
            for (var j = 0; j < 9; j++)
            {
                
                if (!IsCharValid(board[i][j]))
                {
                    return false;
                }
                if (board[i][j] == '.')
                {
                    continue;
                }
                var chr = board[i][j] - '0';  // 1 .. 9
                var two = 1 << (chr - 1); // looks bad, needs <<
                if ((line & two) > 0)
                {
                    return false;
                }
                line = line | two;
                if ((columns[j] & two) > 0)
                {
                    return false;
                }
                columns[j] = columns[j] | two;
                var gridIndex = i / 3 * 3 + j / 3;
                if ( (grids[gridIndex] & two) > 0)
                {
                    return false;
                }
                grids[gridIndex] = grids[gridIndex] | two;

            }

        }

        return true;
    }
}