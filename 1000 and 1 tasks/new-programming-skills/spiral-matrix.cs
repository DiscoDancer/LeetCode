public class Solution {
    // рамки, направления

    enum Directions {
        Right,
        Down,
        Left,
        Top
    }

    public IList<int> SpiralOrder(int[][] matrix) {
        var result = new List<int>();

        var X = matrix.Length;
        var Y = matrix[0].Length;

        var x = 0;
        var y = 0;
        var direction = Directions.Right;

        var minXIncluding = 0;
        var maxXIncluding = X - 1;
        var minYIncluding = 0;
        var maxYIncluding = Y - 1;

        result.Add(matrix[x][y]);

        while (result.Count() < X*Y) {
            if (direction == Directions.Right) {
                while (y < maxYIncluding) {
                    y++;
                    result.Add(matrix[x][y]);
                    if (y == maxYIncluding) {
                        minXIncluding++;
                    }
                }
                direction = Directions.Down;
            }
            else if (direction == Directions.Down) {
                while (x < maxXIncluding) {
                    x++;
                    result.Add(matrix[x][y]);
                    if (x == maxXIncluding) {
                        maxYIncluding--;
                    }
                }
                direction = Directions.Left;
            }
            else if (direction == Directions.Left) {
                while (y > minYIncluding) {
                    y--;
                    result.Add(matrix[x][y]);
                    if (y == minYIncluding) {
                        maxXIncluding--;
                    }
                }
                 direction = Directions.Top;
            }
            else if (direction == Directions.Top) {
                while (x > minXIncluding) {
                    x--;
                    result.Add(matrix[x][y]);
                    if (x == minXIncluding) {
                        minYIncluding++;
                    }
                }
                direction = Directions.Right;
            }
        }

        return result;
    }
}