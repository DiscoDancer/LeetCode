public class Solution {
    
    public bool Has1d(int[] arr, int x) {
        var L = 0;
        var R = arr.Length - 1;
        
        while (L <= R) {
            var M = L + (R - L) / 2;
            
            if (arr[M] == x) {
                return true;
            }
            else if (arr[M] > x) {
                R = M -1;
            }
            else {
                L = M + 1;
            }
        }
        
        return false;
    }
    
    public bool SearchMatrix(int[][] matrix, int target) {
        
        var suspiciousRowIndex = -1;
        
        for (int i = matrix.Length - 1; i >= 0 && suspiciousRowIndex == -1; i--) {
            if (matrix[i][0] == target) {
                return true;
            }
            if (matrix[i][0] < target) {
                suspiciousRowIndex = i;
            }
        }
        
        if (suspiciousRowIndex > -1) {
            return Has1d(matrix[suspiciousRowIndex], target);
        }
        
        return false;
        
        // идти с конца и найти первый, который меньше
    }
}