public class Solution {
    // Struct-like class in Java
    public class Point {
        public int x;
        public int y;

        // Constructor
        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }

    public void rotate(int[][] matrix) {
        var n = matrix.length;

        var circleSize = n;
        // мыслим кругами, начиная с внешнего и заканчивая внутренним
        for (var circleIndex = 0; circleIndex <= n / 2; circleIndex++) {
            // ставим 4 точки, которые будут постепенно смещаться
            var topLeft = new Point(circleIndex, circleIndex);
            var topRight = new Point(circleIndex, circleIndex + circleSize - 1);
            var bottomRight = new Point(circleIndex + circleSize - 1, circleIndex + circleSize - 1);
            var bottomLeft = new Point(circleIndex + circleSize - 1, circleIndex);

            // меняем местами 4 точки и смещаем их
            for (var swapIndex = 0; swapIndex < circleSize - 1; swapIndex++) {
                var topRightOriginal = matrix[topRight.x][topRight.y];
                matrix[topRight.x][topRight.y] = matrix[topLeft.x][topLeft.y];
                var bottomRightOriginal = matrix[bottomRight.x][bottomRight.y];
                matrix[bottomRight.x][bottomRight.y] = topRightOriginal;
                var bottomLeftOriginal = matrix[bottomLeft.x][bottomLeft.y];
                matrix[bottomLeft.x][bottomLeft.y] = bottomRightOriginal;
                matrix[topLeft.x][topLeft.y] = bottomLeftOriginal;

                topLeft.y++;
                topRight.x++;
                bottomRight.y--;
                bottomLeft.x--;
            }
            circleSize -= 2;
        }
    }
}