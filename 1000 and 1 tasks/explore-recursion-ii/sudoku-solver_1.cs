public class Solution {
    private char[][] _board;
    private bool _found = false;
    // они нужны потом, что если в конце цифры уже были, то мы закончим раньше
    private int _countMissing = 0;

    private void F(int index) {
        if (_countMissing == 0) {
            return;
        }

        var row = index / 9;
        var col = index % 9;

        if (_board[row][col] != '.') {
            F(index+1);
            return;
        }

        var possibleValues = new List<char>() {'1','2', '3', '4', '5', '6', '7', '8', '9'};

        // row + col
        for (int i = 0; i < 9; i++) {
            if (_board[row][i] != '.') {
                possibleValues.Remove(_board[row][i]);
            }
            if (_board[i][col] != '.') {
                possibleValues.Remove(_board[i][col]);
            }
        }

        // square
        // в каком мы квадрате?

        // квадратные координаты
        var row2 = row / 3;
        var col2 = col / 3;
        var squareNumer = row2*3 + col2;

        for (int i = row2 * 3; i < row2 * 3 + 3; i++) {
            for (int j = col2*3; j <  col2*3 + 3; j++) {
                if (_board[i][j] != '.') {
                    possibleValues.Remove(_board[i][j]);
                }
            }
        }

        foreach (var possibleValue in possibleValues) {
            _board[row][col] = possibleValue;
            _countMissing--;
            if (_countMissing == 0) {
                return;
            }
            F(index+1);
            // важно не перекрывать результат
            if (_countMissing == 0) {
                return;
            }
            _board[row][col] = '.';
            _countMissing++;
        }
    }

    // Полный перебор был BFS, но нужно хранить доску
    // вычисляем какое число можно вставить, вставили -> идем дальше

    public void SolveSudoku(char[][] board) {
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                if (board[i][j] == '.') {
                    _countMissing++;
                }
            }
        }

        _board = board;

        F(0);
    }
}