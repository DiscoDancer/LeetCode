import java.util.Arrays;
import java.util.Comparator;

// TL

class Solution {

    public int s (int n) {
        return n * (n + 1) / 2;
    }

    public int arrangeCoins(int n) {
        for (var i = 1; i < Integer.MAX_VALUE; i++) {
            if (s(i) == n) {
                return i;
            }
            if (s(i) > n) {
                return i - 1;
            }
        }

        return -1;
    }
}
