public class Solution {
    private int[][] _board;


    private int countAliveNeighbours(int x, int y) {
        var result = 0;

        if (x > 0 && _board[x - 1][y] % 2 == 1) {
            result++;
        }
        if (x < _board.length - 1 && _board[x + 1][y] % 2 == 1) {
            result++;
        }
        if (y > 0 && _board[x][y - 1] % 2 == 1) {
            result++;
        }
        if (y < _board[0].length - 1 && _board[x][y + 1] % 2 == 1) {
            result++;
        }
        if (x > 0 && y > 0 && _board[x - 1][y - 1] % 2 == 1) {
            result++;
        }
        if (x > 0 && y < _board[0].length - 1 && _board[x - 1][y + 1] % 2 == 1) {
            result++;
        }
        if (x < _board.length - 1 && y > 0 && _board[x + 1][y - 1] % 2 == 1) {
            result++;
        }
        if (x < _board.length - 1 && y < _board[0].length - 1 && _board[x + 1][y + 1] % 2 == 1) {
            result++;
        }

        return result;
    }

    private final int WAS_ALIVE_NOW_DEAD = 3;
    private final int WAS_DEAD_NOW_ALIVE = 4;

    public void gameOfLife(int[][] board) {
        _board = board;

        for (var x = 0; x < board.length; x++) {
            for (var y = 0; y < board[0].length; y++) {
                var aliveNeighbours = countAliveNeighbours(x, y);
                if (board[x][y] == 1) {
                    if (aliveNeighbours < 2) {
                        board[x][y] = WAS_ALIVE_NOW_DEAD;
                    }
                    else if (aliveNeighbours == 2 || aliveNeighbours == 3) {
                        board[x][y] = 1; // not changed
                    }
                    else {
                        board[x][y] = WAS_ALIVE_NOW_DEAD;
                    }
                } else if (aliveNeighbours == 3) {
                    board[x][y] = WAS_DEAD_NOW_ALIVE;
                }
            }
        }

        for (var x = 0; x < board.length; x++) {
            for (var y = 0; y < board[0].length; y++) {
                if (board[x][y] == WAS_ALIVE_NOW_DEAD) {
                    board[x][y] = 0;
                } else if (board[x][y] == WAS_DEAD_NOW_ALIVE) {
                    board[x][y] = 1;
                }
                // otherwise, the cell is already in the correct state
            }
        }
    }
}