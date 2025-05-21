import java.util.Arrays;
import java.util.Comparator;

class Solution {

    public long s (long n) {
        return n * (n + 1) / 2;
    }

    public int arrangeCoins(int n) {

        var l = 1;
        var r = n;

        while (l <= r) {
            var m = l + (r - l) / 2;

            if (s(m) == n || s(m) < n && s(m + 1) > n) {
                return m;
            }

            if (s(m) < n) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }


        return -1;
    }
}
