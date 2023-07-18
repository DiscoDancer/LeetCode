public class Solution {
    private char[][] _board;
    // они нужны потом, что если в конце цифры уже были, то мы закончим раньше
    private int _countMissing = 0;

    private int[] _columns = new int[9];
    private int[] _rows = new int[9];
    private int[] _squares = new int[9];

    private void F(int index) {
        if (_countMissing == 0) {
            return;
        }

        var row = index / 9;
        var col = index % 9;
        var squareNumber = (row / 3) * 3 + col / 3;

        if (_board[row][col] != '.') {
            F(index+1);
            return;
        }
        
        var possibleValues =  _rows[row] | _columns[col] | _squares[squareNumber];

        var x = 2;
        var k = 1;
        while (x < 1024)
        {
            if ((possibleValues & x) == 0)
            {
                var possibleValue = k;
                _board[row][col] = (char) (possibleValue + '0');
            
                _rows[row] |= (1 << possibleValue);
                _columns[col] |= (1 << possibleValue);
                _squares[squareNumber] |= (1 << possibleValue);
            
                _countMissing--;
                if (_countMissing == 0) {
                    return;
                }
                F(index+1);
                // важно не перекрывать результат
                if (_countMissing == 0) {
                    return;
                }
                _rows[row] ^= (1 << possibleValue);
                _columns[col] ^= (1 << possibleValue);
                _squares[squareNumber] ^= (1 << possibleValue);
                _board[row][col] = '.';
                _countMissing++;
            }
            
            x <<= 1;
            k++;
        }
    }
    
    public void SolveSudoku(char[][] board) {
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                if (board[i][j] == '.') {
                    _countMissing++;
                }
                else {
                    var num = board[i][j]-'0';
                    _rows[i] |= (1 << num);
                    _columns[j] |= (1 << num);
                    var squareNumber = (i / 3) * 3 + j / 3;
                    _squares[squareNumber] |= (1 << num);
                }
            }
        }

        _board = board;

        F(0);
    }
}