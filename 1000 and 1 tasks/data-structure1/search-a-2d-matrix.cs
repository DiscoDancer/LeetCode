public class Solution {

    private int X;
    private int Y;

    public int GetByGlobalIndex(int[][] matrix, int globalIndex) {
        return matrix[globalIndex / Y] [globalIndex % Y];
    }

    public bool SearchMatrix(int[][] matrix, int target) {
        X = matrix.Length;
        Y = matrix[0].Length;

        var a = 0;
        var b = X*Y - 1;

        while (a <= b) {
            var m = a + (b-a)/2;
            var mValue = GetByGlobalIndex(matrix, m);
            if (mValue == target) {
                return true;
            }
            else if (mValue < target) {
                a = m + 1;
            }
            else {
                b = m - 1;
            }
        }

        return false;
    }
}