import java.util.*;

class Solution {

    public int rangeBitwiseAnd(int left, int right) {

        var max = Math.max(left, right);
        var min = Math.min(left, right);

        var result = max & min;

        for (var bitI = 0; bitI < 31; bitI++) {
            var curBit = ((max >> (30 - bitI)) & 1);
            if (curBit == 0) {
                continue;
            }

            var x = ~(1 << (30 - bitI));
            // нулим текущий бит в максимуме и смотрим попадает ли он в диапазон
            var candidate = max & x;

            if (candidate >= min && candidate <= max) {
                result = result & x;
            }
        }
        
        return result;
    }
}