import java.util.*;

class Solution {

    public int rangeBitwiseAnd(int left, int right) {

        var max = Math.max(left, right);
        var min = Math.min(left, right);

        var result = max & min;

        // 11111...111
        var maskOnes = Integer.MAX_VALUE;

        // пропускаем первый бит под знак
        // from left to right
        // skip leading zeroes
        var bitI = 0;
        while (bitI < 31 && ((max >> (30 - bitI)) & 1) == 0) {
            var x = ~(1 << (30 - bitI));
            // make leading zeroes 0 in 1..1 mask
            maskOnes = maskOnes & x;
            bitI++;
        }

        while (bitI < 31) {
            var x = ~(1 << (30 - bitI));

            // нулим текущий бит в максимуме реальном и теоритическом максимуме
            var rangeMin = max & x;
            var rangeMax = maskOnes & x;

            if (rangeMin >= min && rangeMin <= max || rangeMax >= min && rangeMax <= max) {
                result = result & x;
            }

            bitI++;
        }
        
        return result;
    }
}