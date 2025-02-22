class Solution {

    private static int get(int[][] matrix, int i) {
        var n = matrix.length;
        var m = matrix[0].length;

        return matrix[i / m][i % m];
    }

    public boolean searchMatrix(int[][] matrix, int target) {

        var n = matrix.length;
        var m = matrix[0].length;

        var l = 0;
        var r = n * m - 1;

        while (l <= r) {
            var mid = l + (r - l) / 2;
            var midV = get(matrix, mid);

            if (midV == target) {
                return true;
            }
            else if (midV < target) {
                l = mid + 1;
            }
            else {
                r = mid - 1;
            }
        }

        return false;
    }
}