public class TicTacToe {

    /*
        - сначала по тупому все проверки на каждый ход
        - потом по умноу сумма должна быть n (с не с диагоналями)
    */

    private int _n;

    private int[] _columns1;
    private int[] _columns2;

    private int[] _rows1;
    private int[] _rows2;

    private int _diagonalMain1 = 0;
    private int _diagonalMain2 = 0;

    private int _diagonalSecondary1 = 0;
    private int _diagonalSecondary2 = 0;

    public TicTacToe(int n) {
        _n = n;
        _columns1 = new int[n];
        _columns2 = new int[n];
        _rows1 = new int[n];
        _rows2 = new int[n];
    }
    
    public int Move(int row, int col, int player) {
        if (player == 1) {
            _rows1[row]++;
            _columns1[col]++;
            if (_rows1[row] == _n || _columns1[col] == _n) {
                return 1;
            }
            if (row == col) {
                _diagonalMain1++;
                if (_diagonalMain1 == _n) {
                    return 1;
                }
            }
            if (row + col + 1 == _n) {
                _diagonalSecondary1++;
                if (_diagonalSecondary1 == _n) {
                    return 1;
                }
            }
        }
        else if (player == 2) {
            _rows2[row]++;
            _columns2[col]++;
            if (_rows2[row] == _n || _columns2[col] == _n) {
                return 2;
            }
            if (row == col) {
                _diagonalMain2++;
                if (_diagonalMain2 == _n) {
                    return 2;
                }
            }
            if (row + col + 1 == _n) {
                _diagonalSecondary2++;
                if (_diagonalSecondary2 == _n) {
                    return 2;
                }
            }
        }

        return 0;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */