public class NumMatrix {
   private int[][] Table {
      get;
      set;
   }

   public NumMatrix(int[][] matrix) {
      var Rows = matrix.Length;
      var Cols = matrix[0].Length;

      var tableCols = new int[Rows + 1][];
      tableCols[0] = new int[Cols];
      for (int i = 1; i <= Rows; i++) {
         tableCols[i] = new int[Cols];
         for (int j = 0; j < Cols; j++) {
            tableCols[i][j] = tableCols[i - 1][j] + matrix[i-1][j];
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
   
   // input is 0-based
   public int SumRegion(int row1, int col1, int row2, int col2) {
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
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */