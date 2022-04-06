public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        
        var X = matrix.Length;
        var Y = matrix[0].Length;
        
        var L = 0;
        var R = X*Y - 1;
        
        while (L <= R) {
            var M = L + (R - L) / 2;
            var matrixM = matrix[M / Y][M % Y];
            
            if (matrixM == target) {
                return true;
            }
            else if (matrixM > target) {
                R = M -1;
            }
            else {
                L = M + 1;
            }
            
        }
        
        return false;
    }
}