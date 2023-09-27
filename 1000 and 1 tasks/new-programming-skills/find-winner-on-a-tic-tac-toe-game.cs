public class Solution {

    private string CalcWinner(char? [,] board) {
        if (
            // rows
            board[0,0] == 'X' && board[0,1] == 'X' && board[0,2] == 'X' || 
            board[1,0] == 'X' && board[1,1] == 'X' && board[1,2] == 'X' || 
            board[2,0] == 'X' && board[2,1] == 'X' && board[2,2] == 'X' ||
            // cols
            board[0,0] == 'X' && board[1,0] == 'X' && board[2,0] == 'X' ||
            board[0,1] == 'X' && board[1,1] == 'X' && board[2,1] == 'X' ||
            board[0,2] == 'X' && board[1,2] == 'X' && board[2,2] == 'X' ||
            // diagonal
            board[0,0] == 'X' && board[1,1] == 'X' && board[2,2] == 'X' ||
            board[2,0] == 'X' && board[1,1] == 'X' && board[0,2] == 'X'
            ) {
                return "A";
            }

                    if (
            // rows
            board[0,0] == 'Y' && board[0,1] == 'Y' && board[0,2] == 'Y' || 
            board[1,0] == 'Y' && board[1,1] == 'Y' && board[1,2] == 'Y' || 
            board[2,0] == 'Y' && board[2,1] == 'Y' && board[2,2] == 'Y' ||
            // cols
            board[0,0] == 'Y' && board[1,0] == 'Y' && board[2,0] == 'Y' ||
            board[0,1] == 'Y' && board[1,1] == 'Y' && board[2,1] == 'Y' ||
            board[0,2] == 'Y' && board[1,2] == 'Y' && board[2,2] == 'Y' ||
            // diagonal
            board[0,0] == 'Y' && board[1,1] == 'Y' && board[2,2] == 'Y' ||
            board[2,0] == 'Y' && board[1,1] == 'Y' && board[0,2] == 'Y'
            ) {
                return "B";
            }


        return null;
    }

    // x = true, y = false
    public string Tictactoe(int[][] moves) {

        var board = new char?[3,3];
        
        for (int i = 0; i < moves.Length; i++) {
            var x = moves[i][0];
            var y = moves[i][1];

            if (board[x,y] == null) {
                board[x,y] = i % 2 == 0 ? 'X' : 'Y';
                var winner = CalcWinner(board);
                if (winner != null) {
                    return winner;
                }
                if (i == 8) {
                    return "Draw";
                }
            }
            else {
                return "Error";
            }
        }

         return "Pending";
    }
}