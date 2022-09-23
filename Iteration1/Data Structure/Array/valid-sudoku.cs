public class Solution {
    
    /*
        + check char
        + check rows
        + check cols
        + check squares
        - validate
    */
    
    public bool IsValidSudoku(char[][] board) {
        // вместо словарей bool[9]
        // проверять символы
        
        var rows = new bool[9][];
        var cols = new bool[9][];
        var squares = new bool[9][];
        
        for (int i = 0; i < 9; i++) {
            rows[i] = new bool[9];
            for (int j = 0; j < 9; j++) {
                if   ( !(board[i][j] == '.' || char.IsDigit(board[i][j]))) {
                  return false;   
                }
                if (i == 0) {
                    cols[j] = new bool[9];
                    squares[j] = new bool[9];
                }
                if (char.IsDigit(board[i][j])) {
                    var digit = board[i][j] - '1'; // or - '0'
                    
                    if (rows[i][digit]) {
                        return false;
                    }
                    rows[i][digit] = true;
                    
                    if (cols[j][digit]) {
                        return false;
                    }
                    cols[j][digit] = true;
                    
                    var sqIndex = (i / 3)*3 + j / 3; // incorrect
                    if (squares[sqIndex][digit]) {
                        return false;
                    }
                    squares[sqIndex][digit] = true;
                }
            }
        }
        
        return true;
    }
}