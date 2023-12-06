public class Solution {
    // какая размерность у результата
    public int[][] Multiply(int[][] A, int[][] B) {
        var linesCountA = A.Length;
        var columnsCountA = A[0].Length;

        var linesCountB = B.Length;
        var columnsCountB = B[0].Length;

        // linesCountA = количество строк в С
        // columnsCountB = колиечтсов столбов в С

        var C = new int[linesCountA][];
        for (int i = 0; i < linesCountA; i++) {
            C[i] = new int[columnsCountB];
        }

        var cWritten = 0;

        for (int i = 0; i < columnsCountB; i++) {
            var lineLengthA = A[0].Length;

            for (int j = 0; j < linesCountA; j++) {
                var currentResult = 0;
                for (int k = 0; k < lineLengthA; k++) {
                    currentResult += B[k][i] * A[j][k];
                }

                C[cWritten % linesCountA][cWritten / linesCountA] = currentResult;
                cWritten++;
            }
        }

        return C;
    }
}