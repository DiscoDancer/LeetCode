public class Solution {
    // Math
    // нужно min1, min2, min3 тогда найдем d
    // PS мое решение не требует сортировки!
    public int MissingNumber(int[] arr) {
        var min1 = int.MaxValue;
        var min2 = int.MaxValue;
        var min3 = int.MaxValue;
        var sum = 0;
        var count = arr.Length;

        foreach (var x in arr) {
            sum += x;

            if (x < min1) {
                min3 = min2;
                min2 = min1;
                min1 = x;
            }
            else if (x < min2) {
                min3 = min2;
                min2 = x;
            }
            else if (x < min3) {
                min3 = x;
            }
        }

        var d = Math.Min(min3-min2, min2-min1);
        var expectedSum = ((2*min1 + d *(count+1-1)) * (count+1)) / 2;

        return expectedSum - sum;
    }
}