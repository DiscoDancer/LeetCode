import java.math.BigInteger;
import java.util.*;

// see koko-eating-bananas

class Solution {

    private int[] weights;
    private int days;

    private boolean F(int capacity) {
        if (capacity < 0) {
            return false;
        }

        // если буффер изначально полный, то мы заставим взять 1ый день, если нужно
        var buffer = capacity;
        var dayCount = 0;
        for (var w: weights) {
            if (buffer + w > capacity) {
                dayCount++;
                buffer = 0;
            }
            buffer += w;
        }

        return dayCount <= days;
    }

    public int shipWithinDays(int[] weights, int days) {
        this.weights = weights;
        this.days = days;


        // мб слишком много
        var max = Arrays.stream(weights).sum();
        // все должны влезать
        var min = Arrays.stream(weights).max().orElse(0);

        var l = min;
        var r = max;
        while (l <= r) {
            var m = l + (r - l) / 2;
            if (F(m) && (m == min || !F(m - 1))) {
                return m;
            } else if (F(m)) {
                r = m - 1;
            } else {
                l = m + 1;
            }
        }

        return 42;
    }
}