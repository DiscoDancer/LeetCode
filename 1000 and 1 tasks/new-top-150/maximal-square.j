class Solution {
    public int maximalSquare(char[][] matrix) {
        var X = matrix.length;
        var Y = matrix[0].length;

        var rangeQueries = new int[X][Y];

        for (var lineI = 0; lineI < X; lineI++) {
            var sum = matrix[lineI][0] - '0';
            rangeQueries[lineI][0] = sum;
            for (var colI = 1; colI < Y; colI++) {
                sum += matrix[lineI][colI] - '0';
                rangeQueries[lineI][colI] = sum;
            }
        }

        for (var colI = 0; colI < Y; colI++) {
            var sum = rangeQueries[0][colI];
            rangeQueries[0][colI] = sum;
            for (var lineI = 1; lineI < X; lineI++) {
                sum += rangeQueries[lineI][colI];
                rangeQueries[lineI][colI] = sum;
            }
        }

        var max = Math.min(1, rangeQueries[X-1][Y-1]);
        var maxPossible = Math.min(X, Y);
        
        for (var x = 0; x < X; x++) {
            for (var y = 0; y < Y; y++) {
                for (var size = Math.min(2, max); size <= maxPossible; size++) {
                    // targetSquare = bigSquare - topSquare - leftSquare + topLeftSquare
                    var bigSquare = rangeQueries[x][y];
                    var topSquare = x - size >= 0 ? rangeQueries[x - size][y] : 0;
                    var leftSquare = y - size >= 0 ? rangeQueries[x][y - size] : 0;
                    var topLeftSquare = x - size >= 0 && y - size >= 0 ? rangeQueries[x - size][y - size] : 0;
                    
                    var targetSquare = bigSquare - topSquare - leftSquare + topLeftSquare;
                    if (targetSquare == size * size) {
                        max = Math.max(max, targetSquare);
                    }
                }
            }
        }
        
        return max;
    }
}
