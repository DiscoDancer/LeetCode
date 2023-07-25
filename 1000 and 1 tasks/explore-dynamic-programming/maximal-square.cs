public class Solution {
    // можно было рисовать ебанные квадраты от каждой точки
    // но я помнил, что есть решение через формулу, порисовал рисунок в итоге его вспомнил

    public int MaximalSquare(char[][] matrix) {
        var n = matrix.Length;
        var m = matrix[0].Length;

        var table = new int[n+1,m+1];

        var max = 0;

        for (int i = 1; i <= matrix.Length; i++) {
            for (int j = 1; j <= matrix[0].Length; j++) {
                var inc = matrix[i-1][j-1] == '1' ? 1 : 0;
                var left = table[i,j-1];
                var top = table[i-1, j];
                var angle = table[i-1,j-1];

                if (inc == 0) {
                    table[i,j] = 0;
                }
                else if (inc == 1) {
                    table[i,j] = inc + Math.Min(angle, Math.Min(left, top));
                }
                
                max = Math.Max(max, table[i,j]);
            }
        }

        return max * max;
    }
}