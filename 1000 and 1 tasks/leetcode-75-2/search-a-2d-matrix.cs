public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        foreach (var row in matrix) {
            foreach(var x in row) {
                if (x == target) {
                    return true;
                }
            }
        }
        return false;
    }
}