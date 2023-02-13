public class Solution {
    // в лоб поварачиваем пока не достигнем
    // просто обсчитать варианты
    public bool FindRotation(int[][] mat, int[][] target) {
        var n = mat.Length;

        var all0 = true;
        var all90 = true;
        var all180 = true;
        var all270 = true;
        for (int i = 0; i < n && (all0 || all90 || all180 || all270); i++) {
            for (int j = 0; j < n && (all0 || all90 || all180 || all270); j++) {
                all0 = all0 && (mat[i][j] == target[i][j]);
                all90 = all90 && (mat[i][j] == target[j][n-1-i]);
                all180 = all180 && (mat[i][j] == target[n-1-i][n-1-j]);
                all270 = all270 && (mat[i][j] == target[n-j-1][i]);
            }
        }

        if (all0 || all90 || all180 || all270) {
            return true;
        }

        return false;
    }
}