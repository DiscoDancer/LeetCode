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

    private int count = 0;

    private void F(int curLength) {
        if (curLength > high) {
            return;
        }
        // no need to stop, we still can continue
        if (curLength >= low && curLength <= high) {
            count++;
        }

        // add 0
        F(curLength + zero);
        // add 1
        F(curLength + one);
    }

    public int countGoodStrings(int low, int high, int zero, int one) {
        this.low = low;
        this.high = high;
        this.zero = zero;
        this.one = one;

        F(0);

        return this.count;
    }
}
