import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;


class Solution {

    private int low;
    private int high;
    private int zero;
    private int one;


    private int F(int curLength) {
        if (curLength > high) {
            return 0;
        }

        var result = 0;

        // no need to stop, we still can continue
        if (curLength >= low && curLength <= high) {
            result++;
        }

        // add 0
        result += F(curLength + zero);
        // add 1
        result += F(curLength + one);

        return result;
    }

    public int countGoodStrings(int low, int high, int zero, int one) {
        this.low = low;
        this.high = high;
        this.zero = zero;
        this.one = one;

        return F(0);
    }
}
