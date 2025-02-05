import java.util.*;

class Solution {

    private int readValueFromMatrixByIndex(int[][] board, int index){
        var n = board.length;
        var pointX = (n-1)-(index-1)/n;
        var isOrderYStraight = (n-1-pointX) % 2 == 0;
        var pointY = isOrderYStraight ? (index-1)%n: ((n-1) - (index-1)%n);
        var valueInMatrix = board[pointX][pointY];
        return valueInMatrix;
    }

    public int snakesAndLadders(int[][] board) {
        var n = board.length;
        var visited = new boolean[n*n+1];

        Queue<Integer> queue = new LinkedList<>();
        queue.add(1);
        visited[1] = true;

        var diceRolls = 0;
        while (!queue.isEmpty()) {
            var size = queue.size();
            for (var s = 0; s < size; s++) {
                var currentIndex = queue.poll();
                if (currentIndex == n*n) {
                    return diceRolls;
                }
                
                for (var nextIndex = currentIndex + 1; nextIndex <= Math.min(currentIndex+6, n*n); nextIndex++) {
                    var valueInMatrix = readValueFromMatrixByIndex(board, nextIndex);
                    if (!visited[nextIndex] && valueInMatrix == -1) {
                        visited[nextIndex] = true;
                        queue.add(nextIndex);
                    }
                    else if (valueInMatrix != -1 && !visited[valueInMatrix]) {
                        visited[nextIndex] = true;
                        visited[valueInMatrix] = true;
                        queue.add(valueInMatrix);
                    }
                }
            }
            diceRolls++;
        }

        return -1;
    }
}