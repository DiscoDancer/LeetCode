import java.math.BigInteger;
import java.util.*;

class Solution {

    private int[] weights;
    private int days;

    private boolean F(int capacity) {
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

        for (var capacity = min; capacity <= max; capacity++) {
            if (F(capacity)) {
                return capacity;
            }
        }

        return 42;
    }
}