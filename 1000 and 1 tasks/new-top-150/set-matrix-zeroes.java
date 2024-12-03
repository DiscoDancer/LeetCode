public class Solution {
    public void setZeroes(int[][] matrix) {
        var prevLineHasZero = false;
        for (var i = 0; i < matrix.length; i++) {

            var thisLineHasZero = false;
            for (var j = 0; j < matrix[0].length; j++) {
                if (matrix[i][j] == 0) {
                    thisLineHasZero = true;

                    // один while все равно напрягает
                    // но нельзя тормозить по нулю, потому что 0 может быть получен из-за строки
                    var itop = i - 1;
                    while (itop >= 0) {
                        matrix[itop--][j] = 0;
                    }
                }
                if (i > 0 && matrix[i-1][j] == 0) {
                    matrix[i][j] = 0;
                }
            }
            if (prevLineHasZero) {
                for (var j = 0; j < matrix[0].length; j++) {
                    matrix[i-1][j] = 0;
                }
            }

            prevLineHasZero = thisLineHasZero;
        }
        if (prevLineHasZero) {
            for (var j = 0; j < matrix[0].length; j++) {
                matrix[matrix.length-1][j] = 0;
            }
        }
    }
}