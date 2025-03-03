class Solution {
    private String _word;
    private char[][] _board;

    public enum Direction {
        START, UP, DOWN, LEFT, RIGHT
    }


    private boolean F(int x, int y, int i, boolean[][] visited, Direction direction) {
        if (i == _word.length()-1) {
            return true;
        }

        var X = _board.length;
        var Y = _board[0].length;

        if (x < X - 1 && _board[x+1][y] == _word.charAt(i+1) && !visited[x+1][y] && direction != Direction.UP) {
            visited[x+1][y] = true;
            var result = F(x+1, y, i+1, visited, Direction.DOWN);
            visited[x+1][y] = false;
            if (result) {
                return true;
            }
        }
        if (x > 0 && _board[x-1][y] == _word.charAt(i+1) && !visited[x-1][y] && direction != Direction.DOWN) {
            visited[x-1][y] = true;
            var result = F(x-1, y, i+1, visited, Direction.UP);
            visited[x-1][y] = false;
            if (result) {
                return true;
            }
        }
        if (y < Y - 1 && _board[x][y+1] == _word.charAt(i+1) && !visited[x][y+1] && direction != Direction.LEFT) {
            visited[x][y+1] = true;
            var result = F(x, y+1, i+1, visited, Direction.RIGHT);
            visited[x][y+1] = false;
            if (result) {
                return true;
            }
        }
        if (y > 0 && _board[x][y-1] == _word.charAt(i+1) && !visited[x][y-1] && direction != Direction.RIGHT) {
            visited[x][y-1] = true;
            var result = F(x, y-1, i+1, visited, Direction.LEFT);
            visited[x][y-1] = false;
            if (result) {
                return true;
            }
        }

        return false;
    }

    public boolean exist(char[][] board, String word) {
        _word = word;
        _board = board;

        var X = board.length;
        var Y = board[0].length;

        var visited = new boolean[board.length][board[0].length];

        for (var x = 0; x < X; x++) {
            for (var y = 0; y < Y; y++) {
                if (board[x][y] == word.charAt(0)) {
                    visited[x][y] = true;
                    var result = F(x, y, 0, visited, Direction.START);
                    if (result) {
                        return true;
                    }
                    visited[x][y] = false;
                }
            }
        }

        return false;
    }
}