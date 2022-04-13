public class Solution {
    public int DiagonalSum(int[][] mat) {
        var res = 0;
        
        for (var i = 0; i < mat.Length; i++) {
            res += mat[i][i];
            res += mat[i][mat.Length - i - 1];
        }
        
        if (mat.Length % 2 == 1) {
            res -= mat[mat.Length / 2][mat.Length / 2];
        }
        
        return res;
    }
}