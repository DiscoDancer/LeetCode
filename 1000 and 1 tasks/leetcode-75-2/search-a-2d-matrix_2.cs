public class Solution {

    // Я НЕПРАВИЛЬНО ПОНЯЛ ЗАДАЧУ -> МАССИВ ОТСОРТИРОВАН
    public bool BSRow(int[] arr, int target) {
        var a = 0;
        var b = arr.Length - 1;

        while (a <= b) {
            var m = (b-a)/2 + a;
            if (arr[m] == target) {
                return true;
            }
            else if (arr[m] < target) {
                a = m + 1;
            }
            else {
                b = m - 1;
            }
        }

        return false;
    }

    // найти первый <= x
    public int BSColumn(int[][] matrix, int target) {
        var a = 0;
        var b = matrix.Length - 1;

        while (a <= b) {
            var m = (b-a)/2 + a;

            if (matrix[m][0] <= target) {
                a = m + 1;
            }
            else {
                b = m - 1;
            }
        }

        return a - 1;
    }

    public bool SearchMatrix(int[][] matrix, int target) {
        var startingColumnIndex = BSColumn(matrix, target);
        while (startingColumnIndex >= 0) {
            var found = BSRow(matrix[startingColumnIndex], target);
            if (found) {
                return true;
            }
            startingColumnIndex--;
        }
        return false;
    }
}