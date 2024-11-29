import java.util.*;

public class Solution {

    public enum Direction {
        RIGHT,
        DOWN,
        LEFT,
        UP
    }

    public List<Integer> spiralOrder(int[][] matrix) {
        var lineCount = matrix.length;
        var columnCount = matrix[0].length;
        var n = lineCount * columnCount;

        var result = new ArrayList<Integer>();

        var left = 0;
        var right = columnCount - 1;
        var top = 0;
        var bottom = lineCount - 1;

        var state = Direction.RIGHT;
        while (result.size() < n) {
            switch (state) {
                case RIGHT:
                    for (var j = left; j <= right; j++) {
                        result.add(matrix[top][j]);
                    }
                    top++;
                    state = Direction.DOWN;
                    break;
                case DOWN:
                    for (var i = top; i <= bottom; i++) {
                        result.add(matrix[i][right]);
                    }
                    right--;
                    state = Direction.LEFT;
                    break;
                case LEFT:
                    for (var j = right; j >= left; j--) {
                        result.add(matrix[bottom][j]);
                    }
                    bottom--;
                    state = Direction.UP;
                    break;
                case UP:
                    for (var i = bottom; i >= top; i--) {
                        result.add(matrix[i][left]);
                    }
                    left++;
                    state = Direction.RIGHT;
                    break;
                default:
                    throw new RuntimeException();
            }
        }


        return result;
    }
}