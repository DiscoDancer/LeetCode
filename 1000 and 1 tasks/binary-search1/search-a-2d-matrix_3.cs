public class Solution {
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
        
        var arr = matrix[b];
        a = 0;
        b = arr.Length - 1;
        
        while (a <= b) {
            var m = a + (b-a)/2;
            if (arr[m] == target) {
                return true;
            }
            else if (arr[m] < target) {
                a = m + 1;
            }
            else if (arr[m] > target) {
                b = m - 1;
            }
        }
                
        return false;
        
    }
}