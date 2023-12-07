public class Solution {
    // какая размерность у результата
    public int[][] Multiply(int[][] A, int[][] B) {
        var linesCountA = A.Length;
        var columnsCountA = A[0].Length;

        var linesCountB = B.Length;
        var columnsCountB = B[0].Length;

        var linesCountC = linesCountA;
        var columnsCountC = columnsCountB;

        var C = new int[linesCountC][];
        for (int i = 0; i < linesCountC; i++) {
            C[i] = new int[columnsCountC];
        }

        var cWritten = 0;

        for (int i = 0; i < columnsCountB; i++) {
            var lineLengthA = A[0].Length;

            for (int j = 0; j < linesCountA; j++) {
                var currentResult = 0;
                for (int k = 0; k < lineLengthA; k++) {
                    currentResult += B[k][i] * A[j][k];
                }

                C[cWritten % linesCountC][cWritten / linesCountC] = currentResult;
                cWritten++;
            }
        }

        return C;
    }
}