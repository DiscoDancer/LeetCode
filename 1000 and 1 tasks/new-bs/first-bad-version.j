import java.util.Arrays;
import java.util.Comparator;

// see find-minimum-in-rotated-sorted-array

class Solution {

    public boolean isBadVersion(int version) {
        throw new RuntimeException();
    }

    public int firstBadVersion(int n) {
        var l = 1;
        var r = n;

        while (l <= r) {
            var m = l + (r - l) / 2;

            // criterion
            if (m == 0 && isBadVersion(m) || m > 0 && isBadVersion(m) && !isBadVersion(m - 1)) {
                return m;
            }
            if (isBadVersion(m)) {
                r = m - 1;
            } else {
                l = m + 1;
            }
        }

        return -1;
    }
}
