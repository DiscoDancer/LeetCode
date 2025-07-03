import java.math.BigInteger;
import java.util.*;

// TL
// 52 / 370 testcases passed

class Solution {

    public int maxValue(int n, int index, int maxSum) {
        var arr = new int[n];
        //var candidate = n-1;
        var candidate = maxSum;
        while (candidate > 0) {

            // todo check if candidate is valid
            arr[index] = candidate;

            // right side
            var r = index + 1;
            while (r < arr.length) {
                // if can reduce, then reduce
                if (arr[r-1] > 1) {
                    arr[r] = arr[r-1] - 1;
                }
                else {
                    arr[r] = 1;
                }
                r++;
            }

            // left side
            var l = index - 1;
            while (l >= 0) {
                // if can reduce, then reduce
                if (arr[l+1] > 1) {
                    arr[l] = arr[l+1] - 1;
                }
                else {
                    arr[l] = 1;
                }
                l--;
            }


            var sum = Arrays.stream(arr).sum();
            if (sum <= maxSum) {
                return candidate;
            }

            candidate--;
        }

        return 42;
    }
}