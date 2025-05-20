import java.util.Arrays;
import java.util.Comparator;

// see valid-perfect-square-1

class Solution {
    public int mySqrt(int x) {
        if (x <= 1) {
            return x;
        }
        var l = 1;
        var r = x;

        while (l <= r) {
            var m = l + (r - l) / 2;
            if (x / m == m) {
                return m;
            }
            else if (x/m > m && x/(m+1) < (m+1)) {
                return m;
            }
            else if (x/m > m) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }

        return -1;
    }
}
