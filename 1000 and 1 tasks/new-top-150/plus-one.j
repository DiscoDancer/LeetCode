import java.util.*;

class Solution {

    public int[] plusOne(int[] digits) {

        var bonus = 1;
        for (int i = digits.length - 1; i >= 0; i--) {
            var sum = digits[i] + bonus;
            digits[i] = sum % 10;
            bonus = sum / 10;
        }

        if (bonus == 0) {
            return digits;
        }

        var result = new int[digits.length + 1];
        result[0] = bonus;
        for (int i = 0; i < digits.length; i++) {
            result[i + 1] = digits[i];
        }

        return result;
    }
}