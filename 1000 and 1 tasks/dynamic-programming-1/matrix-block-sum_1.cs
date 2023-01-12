public class Solution {
    // те же размерности матрицы
    // нужна функция, которой на вход индексы, а она сумму между ними

    private int[][] Table {get; set;}

    // или все таки 2D ее сделать
    private void FillTable(int[][] mat) {
        var Rows = mat.Length;
        var Cols = mat[0].Length;


        Table = new int[Rows][];
        for (int i = 0; i < Rows; i++) {
            Table[i] = new int[Rows + 1];
            for (int j = 0; j < Cols; j++) {
                Table[i][j+1] = Table[i][j] + mat[i][j];
            }
        }
    }

    private int ReadTable(int row, int a, int b) {
        var arr = Table[row];
        return arr[b+1]-arr[a];
    }

    // n*n*n
    public int[][] MatrixBlockSum(int[][] mat, int k) {
        var Rows = mat.Length;
        var Cols = mat[0].Length;

        FillTable(mat);

        int[][] res = new int[Rows][];

        for (int i = 0; i < Rows; i++) {
            res[i] = new int[Cols];
            for (int j = 0; j < Cols; j++) {
                
                for (var a = Math.Max(0, i-k); a <= Math.Min(Rows - 1, i + k); a++) {
                    var startIndex = Math.Max(0, j-k);
                    var endIndex = Math.Min(Cols - 1, j + k);
                    res[i][j] += ReadTable(a, startIndex, endIndex);
                }
            }
        }

        return res;
    }
}