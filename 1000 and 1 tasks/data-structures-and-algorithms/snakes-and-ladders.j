import java.util.*;


class Solution {

    private int[][] _board;

    private int readBoard(int currentSquare) {
        var n = _board.length;

        var x = (currentSquare - 1) / n;
        var xReversed = n - 1 - x;


        var isYNormalOrder = x % 2 == 0;
        // normal initially
        var y = currentSquare - x * n - 1;
        if (!isYNormalOrder) {
            // symmetric shift
            y = n - 1 - y;
        }
        return _board[xReversed][y];
    }



    public int snakesAndLadders(int[][] board) {
        _board = board;
        var n = board.length;

        var isVisited = new boolean[n * n + 1];

        var queue = new ArrayDeque<Integer>();
        queue.addLast(1);

        var stepsCounter = 0;
        while (!queue.isEmpty()) {
            var size = queue.size();
            for (int i = 0; i < size; i++) {
                var currentSquare = queue.poll();
                if (currentSquare == n*n) {
                    return stepsCounter;
                }
                if (isVisited[currentSquare]) {
                    continue;
                }
                for (var next = currentSquare + 1; next <= Math.min(n * n, currentSquare + 6); next++) {
                    var boardValue = readBoard(next);
                    if (boardValue == -1) {
                        queue.addLast(next);
                    }
                    else {
                        queue.addLast(boardValue);
                    }
                }
                isVisited[currentSquare] = true;
            }
            stepsCounter++;
        }

        return -1;
    }
}