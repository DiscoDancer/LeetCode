public class Solution {
    // editorial
    public List<(int, int)>[] compressMatrix(int[][] matrix) {
        int rows = matrix.Length;
        int cols = matrix[0].Length;
        
        var compressedMatrix = new List<(int, int)>[rows];
        
        for (int row = 0; row < rows; ++row) {
            var currRow = new List<(int, int)>();
            for (int col = 0; col < cols; ++col) {
                if (matrix[row][col] != 0) {
                    currRow.Add((matrix[row][col], col)); 
                }
            }
            compressedMatrix[row] = currRow;
        }
        return compressedMatrix;
    }
    
    public int[][] Multiply(int[][] mat1, int[][] mat2) {
        int m = mat1.Length;
        int k = mat1[0].Length;
        int n = mat2[0].Length;
        
        // Store the non-zero values of each matrix.
        var A = compressMatrix(mat1);
        var B = compressMatrix(mat2);
        
        int[][] ans = new int[m][];
        for (int i = 0; i < m; i++)
        {
            ans[i] = new int[n];
        }
        
        for (int mat1Row = 0; mat1Row < m; ++mat1Row) {
            // Iterate on all current 'row' non-zero elements of mat1.
            foreach (var mat1Element in A[mat1Row]) {
                int element1 = mat1Element.Item1;
                int mat1Col = mat1Element.Item2;

                // Multiply and add all non-zero elements of mat2
                // where the row is equal to col of current element of mat1.
                foreach (var mat2Element in B[mat1Col]) {
                    int element2 = (int)mat2Element.Item1;
                    int mat2Col = (int)mat2Element.Item2;                 
                    ans[mat1Row][mat2Col] += element1 * element2;
                }
            }
        }
        
        return ans;
    }
}