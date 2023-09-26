public class Solution {
    public int[] PlusOne(int[] digits) {
        var acc = 1;

        for (int i = digits.Length - 1; i >= 0; i--) {
            var res = digits[i] + acc;
            digits[i] = res % 10;
            acc = res / 10;
        }

        if (acc == 0) {
            return digits;
        }

        var result = new int[digits.Length + 1];
        result[0] = 1;

        for (int i = 0; i < digits.Length; i++) {
            result[i+1] = digits[i];
        }

        return result;
    }
}