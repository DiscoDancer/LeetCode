import java.util.Arrays;
import java.util.Comparator;

// TL

class Solution {
    public boolean isPerfectSquare(int num) {

        for (var i = 1; i <= Math.max(1,num / 2); i++) {
            if (i * i == num) {
                return true;
            }
        }

        return false;
    }
}
