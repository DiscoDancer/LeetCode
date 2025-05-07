class Solution {
    // editorial based
    public int countNegatives(int[][] grid) {
        var n = grid[0].length;
        var arr = grid[0];
        var firstNegativeIndex = arr.length;
        while (firstNegativeIndex - 1 >= 0 && arr[firstNegativeIndex - 1] < 0) {
            firstNegativeIndex--;
        }
        var result = n - firstNegativeIndex;

        for (var i = 1; i < grid.length; i++) {
            arr = grid[i];
            while (firstNegativeIndex - 1 >= 0 && arr[firstNegativeIndex - 1] < 0) {
                firstNegativeIndex--;
            }
            result += n - firstNegativeIndex;
        }

        return result;
    }
}
