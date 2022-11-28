public class Solution {
    // TODO ищем строку бинарным поиском
    public bool SearchMatrix(int[][] matrix, int target) {
        var a = 0;
        var b = matrix.Length - 1;
        
        while (a <= b) {
            var m = a + (b-a)/2;
            if (matrix[m][0] > target) {
                b = m - 1;
            }
            else if (matrix[m][0] < target) {
                a = m + 1;
            }
            else if (matrix[m][0] == target) {
                return true;
            }
        }
        
        if (b == -1) {
            return false;
        }
        
        // b - строка
        
        var arr = matrix[b];
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == target) {
                return true;
            }
        }
        
        return false;
        
        
        // for (int i = 0; i < matrix.Length; i++) {
        //     for (int j = 0; j < matrix[0].Length; j++) {
        //         if (matrix[i][j] == target) {
        //             return true;
        //         }
        //     }
        // }
        
        return false;
    }
}