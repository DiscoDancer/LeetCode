public class Solution {

    // взял CheckVerticals и CheckHorizontals из editorial

    private bool CheckVerticals(int[][] board)
    {
        var lineCount = board.Length;
        var columnCount = board[0].Length;
        
        var result = false;

        for (int c = 0; c < columnCount; c++)
        {
            for (int l = 1; l < lineCount - 1; l++)
            {
                if (board[l][c] == 0)
                {
                    continue;
                }

                if (Math.Abs(board[l-1][c]) == Math.Abs(board[l][c]) &&
                    Math.Abs(board[l+1][c]) == Math.Abs(board[l][c]))
                {
                    board[l][c] = -Math.Abs(board[l][c]);
                    board[l-1][c] = -Math.Abs(board[l-1][c]);
                    board[l+1][c] = -Math.Abs(board[l+1][c]);
                    result = true;
                }
            }
        }

        return result;
    }

    private bool CheckHorizontals(int[][] board)
    {
        var lineCount = board.Length;
        var columnCount = board[0].Length;

        var result = false;

        for (int l = 0; l < lineCount; l++)
        {
            for (int c = 1; c < columnCount - 1; c++)
            {
                if (board[l][c] == 0)
                {
                    continue;
                }
                if (Math.Abs(board[l][c-1]) == Math.Abs(board[l][c]) &&
                    Math.Abs(board[l][c+1]) == Math.Abs(board[l][c]))
                {
                    board[l][c] = -Math.Abs(board[l][c]);
                    board[l][c-1] = -Math.Abs(board[l][c-1]);
                    board[l][c+1] = -Math.Abs(board[l][c+1]);
                    result = true;
                }
            }
        }

        return result;
    }

    // can be removed
    private void ChangeNegativeToZeroes(int[][] board)
    {
        var lineCount = board.Length;
        var columnCount = board[0].Length;

        for (int l = 0; l < lineCount; l++)
        {
            for (int c = 0; c < columnCount; c++)
            {
                if (board[l][c] < 0)
                {
                    board[l][c] = 0;
                }
            }
        }
    }

    // go until until meet a zero
    private void MoveZeroesUp(int[][] board)
    {
        var lineCount = board.Length;
        var columnCount = board[0].Length;

        for (int c = 0; c < columnCount; c++)
        {
            var nonZeroIndex = lineCount - 1;
            var zeroCount = 0;
            for (int l = lineCount - 1; l >= 0; l--)
            {
                if (board[l][c] == 0)
                {
                    zeroCount++;
                }
                else
                {
                    board[nonZeroIndex--][c] = board[l][c];
                }
            }

            for (int i = 0; i < zeroCount; i++)
            {
                board[i][c] = 0;
            }
        }
    }
    
    public int[][] CandyCrush(int[][] board)
    {
        var needToCheck = true;
        while (needToCheck)
        {
            var anyChanges = false;
            anyChanges |= CheckVerticals(board);
            anyChanges |= CheckHorizontals(board);
            if (anyChanges)
            {
                ChangeNegativeToZeroes(board);
                MoveZeroesUp(board);
                needToCheck = true;
            }
            else
            {
                needToCheck = false;
            }
        }
        
        return board;
    }
}