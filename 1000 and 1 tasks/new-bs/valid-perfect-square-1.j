import java.util.Arrays;
import java.util.Comparator;

class Solution {
    public boolean isPerfectSquare(int num) {

        if (num == 1) {
            return true;
        }

        var l = 1;
        var r = num / 2;
        // / istead of * helps with overlow
        while (l <= r) {
            var mid = l + (r - l) / 2;
            if (num / mid == mid) {
                // case of 5, it should not work for 2*2
                return mid*mid == num;
            } else if (num / mid  < mid) {
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }

        return false;
    }
}
