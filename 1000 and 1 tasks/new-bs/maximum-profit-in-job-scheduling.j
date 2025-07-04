import java.math.BigInteger;
import java.util.*;

// TL


class Solution {

    private int maxProfit = 0;

    private int[] startTime;
    private int[] endTime;
    private int[] profit;

    private void f(int i, int profit, boolean[] isAvailable) {
        if (i >= startTime.length) {
            this.maxProfit = Math.max(this.maxProfit, profit);
            return;
        }

        // skip
        f(i + 1, profit, isAvailable);

        // take
        var start = startTime[i];
        var end = endTime[i];

        var canTake = true;
        var a = start;
        var b = start + 1;

        while (b <= end) {
            if (!isAvailable[a]) {
                canTake = false;
                break;
            }
            a++;
            b++;
        }

        if (canTake) {
            var isAvailableCopy = Arrays.copyOf(isAvailable, isAvailable.length);
            a = start;
            b = start + 1;
            while (b <= end) {
                isAvailableCopy[a] = false;
                a++;
                b++;
            }
            f (i + 1, profit + this.profit[i], isAvailableCopy);
        }
    }

    public int jobScheduling(int[] startTime, int[] endTime, int[] profit) {
        this.startTime = startTime;
        this.endTime = endTime;
        this.profit = profit;

        // все время которое есть
        var min = Arrays.stream(startTime).min().orElse(0);
        var max = Arrays.stream(endTime).max().orElse(0);
        var isAvailable = new boolean[max + 1];
        var i = min;
        while (i <= max) {
            isAvailable[i] = true;
            i++;
        }

        f(0, 0, isAvailable);

        return this.maxProfit;
    }
}