public class Solution {

    private int[][] Table {
      get;
      set;
    }

    private void FillTable(char[][] matrix) {
        var Rows = matrix.Length;
        var Cols = matrix[0].Length;

        var tableCols = new int[Rows + 1][];
        tableCols[0] = new int[Cols];
        for (int i = 1; i <= Rows; i++) {
            tableCols[i] = new int[Cols];
            for (int j = 0; j < Cols; j++) {
                tableCols[i][j] =  tableCols[i - 1][j] + ( matrix[i-1][j] - '0');
            }
        }

        Table = new int[Rows + 1][];
        Table[0] = new int[Cols + 1];
        for (int i = 1; i <= Rows; i++) {
            Table[i] = new int[Cols + 1];
            for (int j = 1; j <= Cols; j++) {
                Table[i][j] = tableCols[i][j-1] + Table[i][j-1];
            }
        }
   }

   private int SumRegion(int row1, int col1, int row2, int col2) {
        // transform to 1-based
        row1++;
        col1++;
        row2++;
        col2++;

        // https://leetcode.com/problems/matrix-block-sum/solutions/477041/java-prefix-sum-with-picture-explain-clean-code-o-m-n/?envType=study-plan&id=dynamic-programming-i&orderBy=most_votes
        var biggest = Table[row2][col2];
        var top = Table[row1-1][col2];
        var left = Table[row2][col1-1];
        var intersect = Table[row1-1][col1-1];

        return biggest - top - left + intersect;
   }

    public int MaximalSquare(char[][] matrix) {
        FillTable(matrix);
        var m = matrix.Length;
        var n = matrix[0].Length;
        var maxSize = Math.Min(m, n);

        for (int size = maxSize; size >= 1; size--) {
            var targetSum = size*size;
            for (int i = 0; i + size <= m; i++) {
                for (int j = 0; j + size <= n; j++) {
                    var curSum = SumRegion(i, j, i + size - 1, j + size - 1);
                    if (curSum == targetSum)
                    {
                        return curSum;
                    }
                }
            }
        }

        return 0;
    }
}